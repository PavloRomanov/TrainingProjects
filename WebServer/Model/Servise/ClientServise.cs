using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Model.Entity;
using System.Text;

namespace Model.Servise
{
    public class ClientServiсe : BaseService<Client>
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=WebServiceDB;Integrated Security=true;"; 

        public ClientServiсe(string path)
            : base(path)
        {
        }        

        public Client GetClientById(Guid id)
        {
            string queryString = "SELECT * FROM Clients WHERE ClientId = @id"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Client client = null;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {                
                    client = new Client(
                        reader.GetGuid(0),
                        reader["name"].ToString(),
                        reader["surname"].ToString(),
                        reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                        reader["phone"] != DBNull.Value ? reader["phone"].ToString() : ""
                        );
                }
                return client;
            }
        }

        public Dictionary<Guid, Client> GetAllClient()
        {
            string queryString = "SELECT * FROM Clients";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Client client = new Client(
                        reader.GetGuid(0),
                        reader["name"].ToString(),
                        reader["surname"].ToString(),
                        reader["address"].ToString(),
                        reader["phone"].ToString()
                        );

                    allhashmodels.Add(client.Id, client);
                }
               
                return allhashmodels;
            }
        }

        public int AddClient(Client client)
        {
            string queryString = "INSERT INTO dbo.Clients VALUES(@id, @name, @surname, @address, @phone)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {               
                SqlCommand command = new SqlCommand(queryString.ToString(), connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = client.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar);
                command.Parameters["@name"].Value = client.Name;
                command.Parameters.Add("@surname", SqlDbType.NVarChar);
                command.Parameters["@surname"].Value = client.Surname;
                command.Parameters.Add("@address", SqlDbType.NVarChar);
                command.Parameters["@address"].Value = client.Address;
                command.Parameters.Add("@phone", SqlDbType.NVarChar);
                command.Parameters["@phone"].Value = client.Phone;

                connection.Open();
                return command.ExecuteNonQuery();
            }           
        }

        public int DeleteClient(Guid id)
        {
            string queryString = "DELETE FROM Clients WHERE ClientId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = id;
                connection.Open();
                 command.ExecuteNonQuery();               
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateClient(Client client)
        {
            string queryString = "UPDATE dbo.Clients SET Name = @name, Surname = @surname, Address = @address, Phone = @phone WHERE  ClientId = @id";
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString.ToString(), connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = client.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar);
                command.Parameters["@name"].Value = client.Name;
                command.Parameters.Add("@surname", SqlDbType.NVarChar);
                command.Parameters["@surname"].Value = client.Surname;
                command.Parameters.Add("@address", SqlDbType.NVarChar);
                command.Parameters["@address"].Value = client.Address;
                command.Parameters.Add("@phone", SqlDbType.NVarChar);
                command.Parameters["@phone"].Value = client.Phone;

                connection.Open();
                Console.WriteLine("queryString = " + queryString);
                result = command.ExecuteNonQuery();
                
            }
            return result;
        }


    }
}
