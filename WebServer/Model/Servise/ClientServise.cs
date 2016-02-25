using System;
using System.Data.SqlClient;
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
            string queryString = "SELECT * FROM Clients WHERE ClientId = '" + id.ToString() + "'";
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                Client client = null;
                SqlCommand command = new SqlCommand(queryString, connection);
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
            queryString.Append("VALUES('").Append(client.Id.ToString()).Append("', '");
            queryString.Append(client.Name).Append("', '");
            queryString.Append(client.Surname).Append("', '");
            queryString.Append(client.Address).Append("', '");
            queryString.Append(client.Phone).Append("');");
                        
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {               
                SqlCommand command = new SqlCommand(queryString.ToString(), connection);
                connection.Open();                
                result = command.ExecuteNonQuery();
            }

            return result;
        }


    }
}
