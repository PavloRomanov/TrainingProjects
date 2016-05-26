using System;
using System.Security.Principal;
using WebShop.Model.ViewModel;
using WebShop.Service.Contract;

namespace WebShop.Service.Extension
{
    public static class PrincipalExtension
    {
        public static ClientViewModel GetClient(this IPrincipal principal)
        {
            ClientViewModel client = new ClientViewModel();
            
            if (GenericPrincipal.Current.Identity.IsAuthenticated)
            {
                IClientService clientService = ServiceLocator.GetClientService();
                int id = Convert.ToInt32(GenericPrincipal.Current.Identity.Name);
                client = clientService.GetModelById(id);                    
            }
            return client;
        }

        public static int? GetClientId(this IPrincipal principal)
        {  
            if (GenericPrincipal.Current.Identity.IsAuthenticated)
            {
                int id = Convert.ToInt32(GenericPrincipal.Current.Identity.Name);
                return id;
            }
            return null;
        }
    }
}
