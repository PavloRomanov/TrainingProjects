using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Servise
{
    public abstract class SQLBaseServise<T> where T : ModelBase
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=WebServiceDB;Integrated Security=true;";
        public string GetConnection()
        {
            return connectionString;
        }

        public abstract T FillFieldsOfModels(SqlDataReader reader);


        public T GetModel(Guid id, string query)
        {
            T result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
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
        public List<T> GetAllModels(string query)
        {
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                List<T> list = new List<T>();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    list.Add(FillFieldsOfModels(reader));
                }
                return list;
            }
        }
    }
        
    

}











    
