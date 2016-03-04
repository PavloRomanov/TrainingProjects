using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Servise
{
    public class SQLAppealService : SQLService<Appeal>, IAppealService
    {
        public SQLAppealService(string tableName)
            :base("Appeals")
        {
        }

        public override void Add(Appeal model)
        {
            throw new NotImplementedException();
        }

        public override Appeal FillFieldsOfModels(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override void Update(Appeal model)
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<Guid, Appeal> InitializeListNewEntitys(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        protected override Appeal InitializeNewEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
