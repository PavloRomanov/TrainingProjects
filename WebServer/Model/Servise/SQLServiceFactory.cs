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
        public override IClientService CreateClientServise()
        {
            SQLClientService sqls = new SQLClientService("Clients");
            return sqls;
            
        }
        public override IManagerService CreateManagerServise()
        {
            SQLManagerService sqlm = new SQLManagerService("Managers");
            return sqlm;
        }
        public override IAppealService CreateAppealServise()
        {
            SQLAppealService sqla = new SQLAppealService("Appeals");
            return sqla;
        }
        public override IFormService CreateFormServise()
        {
            SQLFormService sqlf = new SQLFormService("Form");
            return sqlf;
        }
        
    }
}
