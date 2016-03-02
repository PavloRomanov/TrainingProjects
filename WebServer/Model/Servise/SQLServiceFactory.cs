using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using Model.Servise;

namespace Model.Servise
{
    public class SQLServiceFactory : AbstractServiceFactory
    {
        public override AbstractClientService CreateClientServise(string name)
        {
            SQLClientService sqls = new SQLClientService("Client");
            return sqls;
            
        }
        public override AbstractManagerService CreateManagerServise(string name)
        {
            SQLManagerServise sqlm = new SQLManagerServise("Managers");
            return sqlm;
        }
        public override AbstractAppealService CreateAppealServise(string name)
        {
            throw new NotImplementedException();
        }
        public override AbstractFormService CreateFormServise(string name)
        {
            throw new NotImplementedException();
        }
        
    }
}
