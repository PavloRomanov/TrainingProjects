using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Model.Entity;
using Model.Enum;

namespace Model.Servise
{
    public class SQLAppealService : SQLService<Appeal>, IAppealService
    {
        public SQLAppealService(string tableName)
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
                reader.GetGuid(2),
                (ClientAppeal)Convert.ToInt32(reader[6]));
                appeal.Rez = reader.GetString(3);
                appeal.Comment = reader.GetString(4);
                appeal.References = reader.GetString(5);
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
                reader.GetGuid(2),
                (ClientAppeal)Convert.ToInt32(reader[6]));
                appeal.Rez = reader.GetString(3);
                appeal.Comment = reader.GetString(4);
                appeal.References = reader.GetString(5);
                appeals.Add(appeal.Id, appeal);
            }

            return appeals;
        }
        public override void Add(Appeal appeal)
        {
            string queryInsert = GetInsertQuery();
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                SqlCommand command = new SqlCommand(queryInsert, connection);
                command.Parameters.Add("@appealId", SqlDbType.UniqueIdentifier);
                command.Parameters["@appealId"].SqlValue = appeal.Id;

                command.Parameters.Add("@managerId", SqlDbType.UniqueIdentifier);
                command.Parameters["@managerId"].SqlValue = appeal.IdManager;

                command.Parameters.Add("@clientId", SqlDbType.UniqueIdentifier);
                command.Parameters["@clientId"].SqlValue = appeal.IdClient;

                command.Parameters.Add("@result", SqlDbType.NVarChar);
                command.Parameters["@result"].SqlValue = appeal.Rez;

                command.Parameters.Add("@comment", SqlDbType.NVarChar);
                command.Parameters["@comment"].SqlValue = appeal.Comment;

                command.Parameters.Add("@references", SqlDbType.NVarChar);
                command.Parameters["@references"].SqlValue = appeal.References;

                command.Parameters.Add("@clientappeal", SqlDbType.Int);
                command.Parameters["@clientappeal"].SqlValue = appeal.ClientAppeal;

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
