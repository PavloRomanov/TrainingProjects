using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using System.Data.SqlClient;
using System.Data;

namespace Model.Servise
{
    public abstract class AbstractAppealService : SQLService<Appeal>
    {
        public AbstractAppealService(string tableName)
            :base("Appeals")
        {
        }
        protected override Appeal InitializeNewEntity(SqlDataReader reader)
        {
            Appeal appeal = null;
            while (reader.Read())
            {
                appeal = new Appeal(
                reader.GetGuid(0),
                reader.GetGuid(1),
                reader.GetGuid(2));
            }
            return appeal;
        }
        protected override Dictionary<Guid, Appeal> InitializeListNewEntitys(SqlDataReader reader)
        {
            Dictionary<Guid, Appeal> appeals = new Dictionary<Guid, Appeal>();
            while (reader.Read())
            {
                Appeal appeal = new Appeal(
                reader.GetGuid(0),
                reader.GetGuid(1),
                reader.GetGuid(2));
                appeals.Add(appeal.Id, appeal);
            }

            return appeals;
        }
        public override void Add(Appeal appeal)
        {
            string queryInsert = "INSERT INTO dbo.Appeals VALUES(@id, @clientId, @managerId,@appeal,@result, @comment, @reference)";
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
                command.Parameters["@id"].SqlValue = appeal.Id;

                command.Parameters.Add("@clientId", SqlDbType.NVarChar);
                command.Parameters["@clientId"].SqlValue = appeal.IdClient;

                command.Parameters.Add("@managerId", SqlDbType.NVarChar);
                command.Parameters["@managerId"].SqlValue = appeal.IdManager;

                command.Parameters.Add("@appeal", SqlDbType.NVarChar);
                command.Parameters["@appeal"].SqlValue = appeal.ClientAppeal.ToString();

                command.Parameters.Add("@result", SqlDbType.NVarChar);
                command.Parameters["@result"].SqlValue = appeal.Rez;

                command.Parameters.Add("@Comment", SqlDbType.NVarChar);
                command.Parameters["@Comment"].SqlValue = appeal.Comment;

                command.Parameters.Add("@reference", SqlDbType.NVarChar);
                command.Parameters["@reference"].SqlValue = appeal.References;
                connection.Open();
                var result = command.ExecuteNonQuery();
                Console.WriteLine("~~~~~~~~~~~~~~~~~" + result + "~~~~~~~~~~~~~~~~~~~~~");
            }
        }

        public override void Update(Appeal appeal)
        {
            throw new NotImplementedException();
        }

    }
}
