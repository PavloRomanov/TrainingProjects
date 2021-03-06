﻿
using System;
using System.Runtime.Serialization;
using Model.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Model.Enum;

namespace Model.Servise
{
    public class SQLManagerService : SQLService<Manager>, IManagerService
    {

        public SQLManagerService(string tableName)
            : base("Managers")
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
                    (WorkExperience)Convert.ToInt32(reader["work"]),
                    reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                    reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "",
                    reader["login"] != DBNull.Value ? reader["login"].ToString() : "",
                    reader["password"] != DBNull.Value ? reader["password"].ToString() : "");
            }
            return manager;
        }
        public Manager GetElementByLogin(string login)
        {
            Manager manager;

            foreach (var item in GetAll())
            {
                if (item.Value.Login == login)
                {
                    manager = item.Value;
                    return manager;
                }
            }
        
            return null;
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
                   (WorkExperience)Convert.ToInt32(reader["work"]),
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
            string queryInsert = GetInsertQuery();
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].SqlValue = manager.Id;

                command.Parameters.Add("@name", SqlDbType.NVarChar);
                command.Parameters["@name"].SqlValue = manager.Name;

                command.Parameters.Add("@surname", SqlDbType.NVarChar);
                command.Parameters["@surname"].SqlValue = manager.Surname;

                command.Parameters.Add("@work", SqlDbType.Int);
                command.Parameters["@work"].SqlValue = manager.Work;

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
            string queryString = "UPDATE dbo.Managers SET Name = @name, Surname = @surname,Work = @work , Address = @address, Phone = @phone, Login = @login, Password = @password WHERE  ManagerId = @id";
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

                command.Parameters.Add("@work", SqlDbType.Int);
                command.Parameters["@work"].Value = man.Work;

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
    }
}
