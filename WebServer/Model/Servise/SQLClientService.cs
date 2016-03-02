using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Model.Entity;
using System.Text;


namespace Model.Servise
{
    public class SQLClientService : AbstractClientService
    {
        public SQLClientService(string tableName)
            :base("Clients")
        {
        }
    }
}
