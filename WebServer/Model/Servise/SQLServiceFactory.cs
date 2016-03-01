using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using Model.Servise;

namespace Model.Servise
{
    public class SQLServiceFactory<SQLService> : AbstractServiceFactory<SQLService>
    {
        public override SQLService CreateClientServise(string name)
        {
            /*var sqls = new ClientSQLService("Client");
            return sqls;*/
            throw new NotImplementedException();
        }
        public override SQLService CreateManagerServise(string name)
        {
            throw new NotImplementedException();
        }
        public override SQLService CreateAppealServise(string name)
        {
            throw new NotImplementedException();
        }
        public override SQLService CreateFormServise(string name)
        {
            throw new NotImplementedException();
        }
        
    }
}
