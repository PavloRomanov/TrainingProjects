using System;
using WebShop.Service.Realization;
using WebShop.Service.Contract;

namespace WebShop.Service
{
    public static class ServiceLocator
    {
        public static IClientService GetClientService()
        {
            return new ClientService();
        }
        public static IProductService GetProductService()
        {
            return new ProductService();
        }
    }
}
