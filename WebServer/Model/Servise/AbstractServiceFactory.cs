using System;

namespace Model.Servise
{
    public abstract class AbstractServiceFactory
    {
        public abstract IClientService CreateClientServise();
        public abstract IManagerService CreateManagerServise();
        public abstract IAppealService CreateAppealServise();
        public abstract IFormService CreateFormServise();
    }
}
