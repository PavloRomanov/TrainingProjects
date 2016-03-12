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
        public override IClientService CreateClientService()
        {
            SQLClientService sqls = new SQLClientService("Clients");
            return sqls;
            
        }
        public override IManagerService CreateManagerService()
        {
            SQLManagerService sqlm = new SQLManagerService("Managers");
            return sqlm;
        }
        public override IAppealService CreateAppealService()
        {
            SQLAppealService sqla = new SQLAppealService("Appeals");
            return sqla;
        }
        public override IFormService CreateFormService()
        {
            SQLFormService sqlf = new SQLFormService("Form");
            return sqlf;
        }
        
    }
}
