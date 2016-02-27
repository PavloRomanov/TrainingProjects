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
    public class SQLBaseServise<T> where T : ModelBase
    {
        private string connectionString;
        public SQLBaseServise(string link)
        {
            connectionString = link;
        }
        //  public abstract T FillFieldsOfModels(SqlDataReader reader);


        /*      public T GetElement(Guid id,string query)
              {
                  string queryString = query;
                  using (SqlConnection connection = new SqlConnection(connectionString))
                  {
                      SqlCommand command = new SqlCommand(queryString, connection);
                      command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                      command.Parameters["@id"].Value = id;
                      connection.Open();
                      SqlDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                      {
                          FillFieldsOfModels(SqlDataReader reader);
                      }
                      return ;
                  }
              }


          }*/
    }

}











    
