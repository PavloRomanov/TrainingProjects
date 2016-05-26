using System;
using WebShop.Service.Implementation;
using WebShop.Service.Contract;
using WebShop.Service.UsingSession;

namespace WebShop.Service
{
    public static class ServiceLocator
    {
        public static IClientService GetClientService()
        {
            return new ClientService();
        }

        public static IEmployeeService GetEmployeeService()
        {
            return new EmployeeService();
        }

        public static IProductService GetProductService()
        {
            return new ProductService();
        }

        public static ICategoryService GetCategoryService()
        {
            return new CategoryService();
        }

        public static ISubcategoryService GetSubcategoryService()
        {
            return new SubcategoryService();
        }

        public static IImageService GetImageService()
        {
            return new ImageService();
        }
        public static ICartItemService GetCartItemService()
        {
            return new CartItemService();
        }
        //Session
        public static ICartItemSessionService GetCartItemSessionService()
        {
            return new CartItemSessionService();
        }
    }
}
