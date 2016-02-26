using System;
using System.Runtime.Serialization;
using Model.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Model.Servise
{
    public class ManagerService : BaseService<Manager>
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=WebServiceDB;Integrated Security=true;";
        public ManagerService(string path)
            : base(path)
        {
        }
        public Manager GetManagerById(Guid id)
        {
            string queryString = "SELECT * FROM Managers WHERE ManagerId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);              
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Manager manager = null;
                while (reader.Read())
                {
                         manager = new Manager(
                         reader.GetGuid(0),
                         reader["name"].ToString(),
                         reader["surname"].ToString(),
                         reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                         reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "",
                         reader["login"] != DBNull.Value ? reader["login"].ToString() : "",
                         reader["password"] != DBNull.Value ? reader["password"].ToString() : "");
                
                }
                return manager;
            }
        }

        public List<Manager> GetAllManager()
        {
            string queryString = "SELECT * FROM Managers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                List<Manager> list = new List<Manager>();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                   var manager = new Manager(
                                            reader.GetGuid(0),
                                            reader["name"].ToString(),
                                            reader["surname"].ToString(),
                                            reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                                            reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "",
                                            reader["login"] != DBNull.Value ? reader["login"].ToString() : "",
                                            reader["password"] != DBNull.Value ? reader["password"].ToString() : "");
                    list.Add(manager);
                }
                return list;
            }
        }




        public Manager GetElementByLogin(string login)
        {
            Manager manager;
            lock (access)
            {
                DeSerialContract();

                foreach(var item in allhashmodels)
                {
                    if(item.Value.Login == login)
                    {
                        manager = item.Value;
                        return manager;
                    }
                }                
            }
            return null;
        }
    }
}
