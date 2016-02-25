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
            string queryString = "SELECT * FROM Clients WHERE ClientId = @ID"; // + id.ToString() + "'";
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                Client client = null;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                command.Parameters["@ID"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {                
                    client = new Client(new Guid(reader["clientID"].ToString()), reader["name"].ToString(),
                        reader["surname"].ToString(), reader["address"].ToString(), reader["phone"].ToString());
                }
                return client;
            }
        }

        public Dictionary<Guid, Client> GetAllClient()
        {
            string queryString = "SELECT * FROM Clients";
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                Client client;
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    client = new Client(Guid.Parse(reader["clientID"].ToString()), reader["name"].ToString(),
                        reader["surname"].ToString(), reader["address"].ToString(), reader["phone"].ToString());

                    allhashmodels.Add(client.Id, client);
                }
               
                return allhashmodels;
            }
        }

        public int AddClient(Client client)
        {
            int result = 0;
            StringBuilder queryString = new StringBuilder("INSERT INTO[dbo].[Clients]");
            queryString.Append("VALUES(@id, @name, @surname, @address, @phone)");

            using (SqlConnection connection = new SqlConnection(
               connectionString))
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
                result = command.ExecuteNonQuery();
            }

            return result;
        }


    }
}
