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
            SQLManagerServise sqlm = new SQLManagerServise("Managers");
            return sqlm;
        }
        public override IAppealService CreateAppealServise()
        {
            SQLAppealService sqla = new SQLAppealService("Appeals");
            return sqla;
        }
        public override IFormService CreateFormServise()
        {
            SQLFormServise sqlf = new SQLFormServise("Form");
            return sqlf;
        }
        
    }
}
