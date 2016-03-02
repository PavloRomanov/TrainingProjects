using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using Model.Servise;

namespace Model.Servise
{
    public abstract class AbstractServiceFactory<IService>
    {
        public abstract AbstractClientService CreateClientServise(string name);
        public abstract AbstractManagerService CreateManagerServise(string name);
        public abstract AbstractAppealService CreateAppealServise(string name);
        public abstract AbstractFormService CreateFormServise(string name);
    }
}
