using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddCustomMappers(this IServiceCollection services)
        {
            services.AddSingleton<IViewModelMapper<ApplicationUser, UserViewModel>, UserViewModelMapper>();
            services.AddSingleton<IViewModelMapper<IReadOnlyCollection<ApplicationUser>, AdminViewModel>, AdminViewModelMapper>();
            services.AddSingleton<IViewModelMapper<IReadOnlyCollection<Product>, AdminViewModel>, AdminViewModelMapper>();
            services.AddSingleton<IViewModelMapper<IReadOnlyCollection<Category>, AdminViewModel>, AdminViewModelMapper>();
            services.AddSingleton<IViewModelMapper<IReadOnlyCollection<Supplier>, AdminViewModel>, AdminViewModelMapper>();
            services.AddSingleton<IViewModelMapper<Product, ProductViewModel>, ProductViewModelMapper>();
            services.AddSingleton<IViewModelMapper<Category, CategoryViewModel>, CategoryViewModelMapper>();
            services.AddSingleton<IViewModelMapper<Supplier, SupplierViewModel>, SupplierViewModelMapper>();
            services.AddSingleton<IViewModelMapper<Product, AllProductsViewModel>, AllProductsViewModelMapper>();


            return services;
        }
    }
}
