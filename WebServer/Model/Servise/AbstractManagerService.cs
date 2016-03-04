using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using System.Data.SqlClient;
using System.Data;

namespace Model.Servise
{
    public abstract class AbstractManagerService : SQLService<Manager>
    {
        public AbstractManagerService(string tableName)
            :base("Managers")
        {
        }
        protected override Manager InitializeNewEntity(SqlDataReader reader)
        {
            Manager manager = null;
            while (reader.Read())
            {
                manager = new Manager(
                     reader.GetGuid(0),
                     reader["name"].ToString(),
                     reader["surname"].ToString(),
                     //reader["work"].ToString(),
                     reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                     reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "",
                     reader["login"] != DBNull.Value ? reader["login"].ToString() : "",
                     reader["password"] != DBNull.Value ? reader["password"].ToString() : "");
            }
     
            return manager;
        }

        protected override Dictionary<Guid, Manager> InitializeListNewEntitys(SqlDataReader reader)
        {
            Dictionary<Guid, Manager> managers = new Dictionary<Guid, Manager>();
            while (reader.Read())
            {
               Manager manager = new Manager(
                     reader.GetGuid(0),
                     reader["name"].ToString(),
                     reader["surname"].ToString(),
                    // reader["work"].ToString(),
                     reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                     reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "",
                     reader["login"] != DBNull.Value ? reader["login"].ToString() : "",
                     reader["password"] != DBNull.Value ? reader["password"].ToString() : "");
                
                managers.Add(manager.Id, manager);
            }

            return managers;
        }
        public override void Add(Manager manager)
        {
            string queryString = GetInsertQuery();
            int result = 0;
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryString.ToString(), connection);
                               
                command.Parameters.Add("@ManagerId", SqlDbType.UniqueIdentifier);
                command.Parameters["@ManagerId"].SqlValue = manager.Id;

                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].SqlValue = manager.Name;

                command.Parameters.Add("@Surname", SqlDbType.NVarChar);
                command.Parameters["@Surname"].SqlValue = manager.Surname;

                command.Parameters.Add("@Work", SqlDbType.NVarChar);
                command.Parameters["@Work"].SqlValue = manager.Work.ToString();

                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters["@Address"].SqlValue = manager.Address;

                command.Parameters.Add("@Phone", SqlDbType.NVarChar);
                command.Parameters["@Phone"].SqlValue = manager.Phone;

                command.Parameters.Add("@Login", SqlDbType.NVarChar);
                command.Parameters["@Login"].SqlValue = manager.Login;

                command.Parameters.Add("@Password", SqlDbType.NVarChar);
                command.Parameters["@Password"].SqlValue = manager.Password;

                connection.Open();
                result = command.ExecuteNonQuery();
                Console.WriteLine("~~~~~~~~~~~~~~~~~" + result + "~~~~~~~~~~~~~~~~~~~~~");
            }
        }

        public override void Update(Manager man)
        {
            string queryString = "UPDATE dbo.Managers SET Name = @name, Surname = @surname,Work = @experience , Address = @address, Phone = @phone, Login = @login, Password = @password WHERE  ManagerId = @id";
            int result = 0;

            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = man.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar);
                command.Parameters["@name"].Value = man.Name;
                command.Parameters.Add("@surname", SqlDbType.NVarChar);
                command.Parameters["@surname"].Value = man.Surname;

                command.Parameters.Add("@experience", SqlDbType.NVarChar);
                command.Parameters["@experience"].Value = man.Work.ToString();

                command.Parameters.Add("@address", SqlDbType.NVarChar);
                command.Parameters["@address"].Value = man.Address;
                command.Parameters.Add("@phone", SqlDbType.NVarChar);
                command.Parameters["@phone"].Value = man.Phone;
                command.Parameters.Add("@login", SqlDbType.NVarChar);
                command.Parameters["@login"].Value = man.Login;
                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].Value = man.Password;
                connection.Open();
                Console.WriteLine("queryString = " + queryString);
                result = command.ExecuteNonQuery();
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~" + result + "~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
