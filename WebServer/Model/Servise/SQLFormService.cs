using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Model.Servise
{
   public class SQLFormService : AbstractFormService
    {
        public SQLFormService(string tableName)
            : base("Forms")
        {
        }
     
    }
}
