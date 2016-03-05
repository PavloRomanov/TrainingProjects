﻿using Model.Entity;
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

        public Form GetForm(Guid id)
        {
            string queryString = "SELECT * FROM Forms WHERE FormId = @id";
            Form result = null;
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // result = FillFieldsOfModels(reader);
                }
            }
            return result;
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
            string queryInsert = "INSERT INTO dbo.Forms VALUES(@id, @managerId, @clientId, @Answer1, @Comment1, @Answer2, @Comment2,@Answer3,@Comment3,@Answer4,@Comment4,@Answer5,@Comment5)";
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].SqlValue = form.Id;
              
                command.Parameters.Add("@managerId", SqlDbType.UniqueIdentifier);//////////////////////////////////
                command.Parameters["@managerId"].SqlValue = form.IdManager;

                command.Parameters.Add("@clientId", SqlDbType.UniqueIdentifier);////////////////////////////////
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




        public Form FillFieldsOfModels(SqlDataReader reader)
        {

            Form form = new Form(
                    reader.GetGuid(0),
                    reader.GetGuid(1),
                    reader.GetGuid(2));

            return form;
        }


        public int AddForm(Form form)
        {
            string queryInsert = "INSERT INTO dbo.Managerss VALUES(@id, @nameclient, @namemanager,@Answer1, @Comment1, @Answer2, @Comment2,@Answer3,@Comment3,@Answer4,@Comment4,@Answer5,@Comment5)";
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].SqlValue = form.Id;

                command.Parameters.Add("@nameclient", SqlDbType.NVarChar);
                command.Parameters["@nameclient"].SqlValue = form.IdClient;

                command.Parameters.Add("@namemanager", SqlDbType.NVarChar);
                command.Parameters["@namemanager"].SqlValue = form.IdManager;

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
                return command.ExecuteNonQuery();
            }
        }

    }
}