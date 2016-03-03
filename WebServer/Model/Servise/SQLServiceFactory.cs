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
        public override AbstractClientService CreateClientService(string name)
        {
            SQLClientService sqls = new SQLClientService("Clients");
            return sqls;
            
        }
        public override AbstractManagerService CreateManagerService(string name)
        {
            SQLManagerService sqlm = new SQLManagerService("Managers");
            return sqlm;
        }
        public override AbstractAppealService CreateAppealService(string name)
        {
            SQLAppealService sqla = new SQLAppealService("Appeals");
            return sqla;
        }
        public override AbstractFormService CreateFormService(string name)
        {
            SQLFormService sqlf = new SQLFormService("Forms");
            return sqlf;
        }
        
    }
}
