using Ninject;
using System;
using System.Collections.Generic;
using WebShop.Service.Contract;
using WebShop.Service.Implementation;
using System.Web.Mvc;
namespace WebShop.Service.Infrastructure
{
    public class NinjectDependencyResolver//: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductService>().To<ProductService>();
        }
    }
}
