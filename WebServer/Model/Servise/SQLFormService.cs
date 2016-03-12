using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Model.Servise
{
   public class SQLFormService : SQLService<Form>, IFormService
    {
        public SQLFormService(string tableName)
            : base("Forms")
        {
        }

        protected override Form InitializeNewEntity(SqlDataReader reader)
        {
            Form form = null;
            while (reader.Read())
            {
                form = new Form(
                reader.GetGuid(0),
                reader.GetGuid(1),
                reader.GetGuid(2));
                form.Answer1 = reader.GetString(3);
                form.Comment1 = reader.GetString(4);
                form.Answer2 = reader.GetString(5);
                form.Comment2 = reader.GetString(6);
                form.Answer3 = reader.GetString(7);
                form.Comment3 = reader.GetString(8);
                form.Answer4 = reader.GetString(9);
                form.Comment4 = reader.GetString(10);
                form.Answer5 = reader.GetString(11);
                form.Comment5 = reader.GetString(12);
                
            }
            return form;
        }
        protected override Dictionary<Guid, Form> InitializeListNewEntitys(SqlDataReader reader)
        {
            Dictionary<Guid, Form> forms = new Dictionary<Guid, Form>();
            while (reader.Read())
            {
                Form form = new Form(
                reader.GetGuid(0),
                reader.GetGuid(1),
                reader.GetGuid(2));
                form.Answer1 = reader.GetString(3);
                form.Comment1 = reader.GetString(4);
                form.Answer2 = reader.GetString(5);
                form.Comment2 = reader.GetString(6);
                form.Answer3 = reader.GetString(7);
                form.Comment3 = reader.GetString(8);
                form.Answer4 = reader.GetString(9);
                form.Comment4 = reader.GetString(10);
                form.Answer5 = reader.GetString(11);
                form.Comment5 = reader.GetString(12);
                forms.Add(form.Id, form);
            }
            return forms;
        }

        public override void Add(Form form)
        {
            string queryInsert = GetInsertQuery();
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@formId", SqlDbType.UniqueIdentifier);
                command.Parameters["@formId"].SqlValue = form.Id;
              
                command.Parameters.Add("@managerId", SqlDbType.UniqueIdentifier);
                command.Parameters["@managerId"].SqlValue = form.IdManager;

                command.Parameters.Add("@clientId", SqlDbType.UniqueIdentifier);
                command.Parameters["@clientId"].SqlValue = form.IdClient;

                command.Parameters.Add("@Answer1", SqlDbType.NVarChar);
                command.Parameters["@Answer1"].SqlValue = form.Answer1;
                command.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                command.Parameters["@Comment1"].SqlValue = form.Comment1;

                command.Parameters.Add("@Answer2", SqlDbType.NVarChar);
                command.Parameters["@Answer2"].SqlValue = form.Answer2;
                command.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                command.Parameters["@Comment2"].SqlValue = form.Comment2;

                command.Parameters.Add("@Answer3", SqlDbType.NVarChar);
                command.Parameters["@Answer3"].SqlValue = form.Answer3;
                command.Parameters.Add("@Comment3", SqlDbType.NVarChar);
                command.Parameters["@Comment3"].SqlValue = form.Comment3;

                command.Parameters.Add("@Answer4", SqlDbType.NVarChar);
                command.Parameters["@Answer4"].SqlValue = form.Answer4;
                command.Parameters.Add("@Comment4", SqlDbType.NVarChar);
                command.Parameters["@Comment4"].SqlValue = form.Comment4;

                command.Parameters.Add("@Answer5", SqlDbType.NVarChar);
                command.Parameters["@Answer5"].SqlValue = form.Answer5;
                command.Parameters.Add("@Comment5", SqlDbType.NVarChar);
                command.Parameters["@Comment5"].SqlValue = form.Comment5;

                connection.Open();

                var result = command.ExecuteNonQuery();
                Console.WriteLine("~~~~~~~~~~~~~~~~~" + result + "~~~~~~~~~~~~~~~~~~~~~");
            }
        }

        public override void Update(Form model)
        {
            throw new NotImplementedException();
        }
    }
}
