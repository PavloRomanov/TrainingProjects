using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Servise
{
    public class SQLAppealService : AbstractAppealService
    {
        public SQLAppealService(string tableName)
            :base("Appeals")
        {
        }
    }
}
