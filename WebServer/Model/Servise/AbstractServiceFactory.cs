using System;

namespace Model.Servise
{
    public abstract class AbstractServiceFactory
    {
        public abstract IClientService CreateClientService();
        public abstract IManagerService CreateManagerService();
        public abstract IAppealService CreateAppealService();
        public abstract IFormService CreateFormService();
    }
}
