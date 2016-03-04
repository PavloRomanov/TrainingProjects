
using System;
using System.Runtime.Serialization;
using Model.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Model.Servise
{
    public class SQLManagerService : AbstractManagerService
    {
        
        public SQLManagerService(string tableName)
            :base("Managers")
        {
        }

    }
}
