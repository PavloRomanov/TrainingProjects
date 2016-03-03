using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using System.Data.SqlClient;
using System.Data;

namespace Model.Servise
{
    public abstract class AbstractFormService : SQLService<Form>
    {
        public AbstractFormService(string tableName)
            :base("Forms")
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
                forms.Add(form.Id, form);
            }

            return forms;
        }
        public override void Add(Form form)
        {
            string queryInsert = "INSERT INTO dbo.Forms VALUES(@id, @clientId, @managerId,@Answer1, @Comment1, @Answer2, @Comment2,@Answer3,@Comment3,@Answer4,@Comment4,@Answer5,@Comment5)";
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].SqlValue = form.Id;

                command.Parameters.Add("@clientId", SqlDbType.NVarChar);
                command.Parameters["@clientId"].SqlValue = form.IdClient;

                command.Parameters.Add("@managerId", SqlDbType.NVarChar);
                command.Parameters["@managerId"].SqlValue = form.IdManager;

                command.Parameters.Add("@Answer1", SqlDbType.NVarChar);
                command.Parameters["@Answer1"].SqlValue = form.Answer1;
                command.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                command.Parameters["@Comment1"].SqlValue = form.Comment1;

                command.Parameters.Add("@Answer2", SqlDbType.NVarChar);
                command.Parameters["@Answer2"].SqlValue = form.Answer1;
                command.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                command.Parameters["@Comment2"].SqlValue = form.Comment1;

                command.Parameters.Add("@Answer3", SqlDbType.NVarChar);
                command.Parameters["@Answer3"].SqlValue = form.Answer1;
                command.Parameters.Add("@Comment3", SqlDbType.NVarChar);
                command.Parameters["@Comment3"].SqlValue = form.Comment1;

                command.Parameters.Add("@Answer4", SqlDbType.NVarChar);
                command.Parameters["@Answer4"].SqlValue = form.Answer1;
                command.Parameters.Add("@Comment4", SqlDbType.NVarChar);
                command.Parameters["@Comment4"].SqlValue = form.Comment1;

                command.Parameters.Add("@Answer5", SqlDbType.NVarChar);
                command.Parameters["@Answer5"].SqlValue = form.Answer1;
                command.Parameters.Add("@Comment5", SqlDbType.NVarChar);
                command.Parameters["@Comment5"].SqlValue = form.Comment1;

                connection.Open();
                var result = command.ExecuteNonQuery();
                Console.WriteLine("~~~~~~~~~~~~~~~~~" + result + "~~~~~~~~~~~~~~~~~~~~~");
            }
        }
        public override void Update(Form form)
        {
            throw new NotImplementedException();
        }

    }
}

