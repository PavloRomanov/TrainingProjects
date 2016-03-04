
using System;
using System.Runtime.Serialization;
using Model.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Model.Servise
{
    public class SQLManagerService : SQLService<Manager>, IManagerService
    {

        public SQLManagerService(string tableName)
            : base("Managers")
        {
        }

        public Manager FillFieldsOfModels(SqlDataReader reader)
        {

            Manager manager = new Manager(
                    reader.GetGuid(0),
                    reader["name"].ToString(),
                    reader["surname"].ToString(),
                    reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                    reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "",
                    reader["login"] != DBNull.Value ? reader["login"].ToString() : "",
                    reader["password"] != DBNull.Value ? reader["password"].ToString() : "");
            return manager;
        }
        public override Manager GetElement(Guid id)
        {
            string queryString = "SELECT * FROM Managers WHERE ManagerId = @id";
            Manager result = null;
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = FillFieldsOfModels(reader);
                }
            }
            return result;
        }

        public override Dictionary<Guid, Manager> GetAll()
        {
            string queryString = "SELECT * FROM Managers";
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                Dictionary<Guid, Manager> list = new Dictionary<Guid, Manager>();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Manager manager = FillFieldsOfModels(reader);
                    list.Add(manager.Id, manager);
                }
                return list;
            }
        }
        public override void Add(Manager manager)
        {
            string queryInsert = "INSERT INTO dbo.Managers VALUES(@id, @name, @surname,@experience, @address, @phone, @login,@password)";
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].SqlValue = manager.Id;

                command.Parameters.Add("@name", SqlDbType.NVarChar);
                command.Parameters["@name"].SqlValue = manager.Name;

                command.Parameters.Add("@surname", SqlDbType.NVarChar);
                command.Parameters["@surname"].SqlValue = manager.Surname;

                command.Parameters.Add("@experience", SqlDbType.NVarChar);
                command.Parameters["@experience"].SqlValue = manager.Work.ToString();

                command.Parameters.Add("@address", SqlDbType.NVarChar);
                command.Parameters["@address"].SqlValue = manager.Address;

                command.Parameters.Add("@phone", SqlDbType.NVarChar);
                command.Parameters["@phone"].SqlValue = manager.Phone;

                command.Parameters.Add("@login", SqlDbType.NVarChar);
                command.Parameters["@login"].SqlValue = manager.Login;

                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].SqlValue = manager.Password;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public override void Update(Manager man)
        {
            string queryString = "UPDATE dbo.Managers SET Name = @name, Surname = @surname,Experience = @experience , Address = @address, Phone = @phone, Login = @login, Password = @password WHERE  ManagerId = @id";
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
        }
        public int DeleteManager(Guid id)
        {
            string queryString = "DELETE FROM Managers WHERE ManagerId = @id";
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].SqlValue = id;
                connection.Open();
                return command.ExecuteNonQuery();
            }
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
    }
}
