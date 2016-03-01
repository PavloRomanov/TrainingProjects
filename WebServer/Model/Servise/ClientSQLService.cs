using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Model.Entity;
using System.Text;


namespace Model.Servise
{
    public class ClientSQLService : SQLServise<Client>
    {
        private string tableName;
        private List<string> columName;
        
        private string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=WebServiceDB;Integrated Security=true;";

        public ClientSQLService(string tableName)
            :base("Clients")
        {
            this.tableName = tableName;
            this.columName = GetColumName(tableName);
            SetParameters();
        }

        protected override Client InitializeNewEntity(SqlDataReader reader)
        {
            Client client = null;
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

        protected override Dictionary<Guid, Client> InitializeListNewEntitys(SqlDataReader reader)
        {
            Dictionary<Guid, Client> clients = new Dictionary<Guid, Client>();
            while (reader.Read())
            {
                Client client = new Client(
                    reader.GetGuid(0),
                    reader["name"].ToString(),
                    reader["surname"].ToString(),
                    reader["address"] != DBNull.Value ? reader["address"].ToString() : "",
                    reader["phone"] != DBNull.Value ? reader["phone"].ToString() : ""
                );
                clients.Add(client.Id, client);
            }

            return clients;
        }       
        

        public override void Add(Client client)
        {
            string queryString = GetInsertQuery();            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {               
                SqlCommand command = new SqlCommand(queryString.ToString(), connection);
                command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier);
                command.Parameters["@ClientId"].Value = client.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = client.Name;
                command.Parameters.Add("@Surname", SqlDbType.NVarChar);
                command.Parameters["@Surname"].Value = client.Surname;
                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters["@Address"].Value = client.Address;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar);
                command.Parameters["@Phone"].Value = client.Phone;

                connection.Open();
                int result = command.ExecuteNonQuery();
                Console.WriteLine("~~~~~~~~~~~~~~~~~" + result + "~~~~~~~~~~~~~~~~~~~~~");
            }           
        }

        

        public override void Update(Client client)
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
            
            Console.WriteLine("~~~~~~~~~~~~~~~~~" + result + "~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
