using System;
using System.Collections.Generic;
using Model.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Model.Servise
{
    public abstract class SQLService<T> : IService<T>where T : ModelBase
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=WebServiceDB;Integrated Security=true;";
        private string tableName;
        private List<string> columName = new List<string>();
        protected List<string> parameters = new List<string>();


        public SQLService(string tableName)
        {
            this.tableName = tableName;
            this.columName = GetColumName(tableName);
            SetParameters();
        }

        protected string GetConnection()
        {
            return connectionString;
        }

        protected List<string> GetColumName(string tableName)
        {
            string queryString = new StringBuilder("select info.COLUMN_NAME from (select* from INFORMATION_SCHEMA.columns where TABLE_NAME = N'")
                .Append(tableName).Append("') as info; ").ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    columName.Add(reader[0].ToString());
                }
            }
            return columName;
        }

        //заполнение списка параметров
        protected void SetParameters()
        {
            for(int i =0; i < columName.Count; i++)
            {
                parameters.Add("@" + columName[i].ToString());
            }
        }

        //Инициализирует Entity данными, полученными от SQL Servera
        protected abstract T InitializeNewEntity(SqlDataReader reader);

        //Инициализирует список Entity данными, полученными от SQL Servera
        protected abstract Dictionary<Guid, T> InitializeListNewEntitys(SqlDataReader reader);


        //Строка запроса для получения данных по ID
        protected string GetSelectQueryById()
        {
            StringBuilder query = new StringBuilder("SELECT * FROM ")
                .Append(tableName)
                .Append(" WHERE ")
                .Append(columName[0])
                .Append(" = @id");
            return query.ToString();
        }
      
        //ПОЛУЧЕНИЕ данных по ID
        public virtual T GetElement(Guid id)
        {
            string queryString = GetSelectQueryById();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                T element = InitializeNewEntity(reader);           
                return element;
            }
        }

        //Строка запроса для получение всех данных из таблицы
        protected string GetSelectAllQuery()
        {
            StringBuilder query = new StringBuilder("SELECT * FROM ")
                .Append(tableName);

            return query.ToString();
        }

        //ПОЛУЧЕНИЕ ВСЕХ данных из таблицы
        public virtual Dictionary<Guid, T> GetAll()
        {
            string queryString = GetSelectAllQuery();
            Dictionary<Guid, T> elements = new Dictionary<Guid, T>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                elements = InitializeListNewEntitys(reader);
            }
            return elements;
        }

        //Строка запроса для удаления строки данных из таблицы по ID
        protected string GetDeleteQuery()
        {
            StringBuilder query = new StringBuilder("DELETE FROM ")
                .Append(tableName)
                .Append(" WHERE ")
                .Append(columName[0])
                .Append(" = @id");

            return query.ToString();
        }

        //УДАЛЕНИЕ данных по ID
        public virtual void Delete(Guid id)
        {
            string queryString = GetDeleteQuery();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = id;
                connection.Open();
                command.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        //Строка запроса для добавления данных в таблицу
        protected  string GetInsertQuery()
        {
            StringBuilder query = new StringBuilder("INSERT INTO ")
                .Append(tableName)
                .Append(" VALUES (");
            for(int i = 0; i < columName.Count; i++)
            {
                query.Append(parameters[i]).Append(", ");                
            }
            query.Remove((query.Length - 2), 2).Append(");");                

            return query.ToString();
        }

        //ДОБАВЛЕНИЕ данных в таблицу
        public abstract void Add(T model); 
      
        //ИЗМЕНЕНИЕ данных в таблице по ID
        public abstract void Update(T model);

      

    }
}
