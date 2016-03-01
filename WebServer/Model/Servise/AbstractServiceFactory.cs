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
        public abstract IService CreateClientServise(string name);
        public abstract IService CreateManagerServise(string name);
        public abstract IService CreateAppealServise(string name);
        public abstract IService CreateFormServise(string name);
    }
}
