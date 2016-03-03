using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using Model.Servise;

namespace Model.Servise
{
    public abstract class AbstractServiceFactory
    {
        public abstract AbstractClientService CreateClientService(string name);
        public abstract AbstractManagerService CreateManagerService(string name);
        public abstract AbstractAppealService CreateAppealService(string name);
        public abstract AbstractFormService CreateFormService(string name);
    }
}
