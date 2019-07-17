
using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public class AdminViewModelMapper : IViewModelMapper<IReadOnlyCollection<ApplicationUser>, AdminViewModel>,
        IViewModelMapper<IReadOnlyCollection<Product>, AdminViewModel>,
        IViewModelMapper<IReadOnlyCollection<Category>, AdminViewModel>,
        IViewModelMapper<IReadOnlyCollection<Supplier>, AdminViewModel>
    {
        private readonly IViewModelMapper<ApplicationUser, UserViewModel> userMapper;
        private readonly IViewModelMapper<Product, AllProductsViewModel> productMapper;
        private readonly IViewModelMapper<Category, CategoryViewModel> categoryMapper;
        private readonly IViewModelMapper<Supplier, SupplierViewModel> supplierMapper;

        public AdminViewModelMapper(IViewModelMapper<ApplicationUser, UserViewModel> userMapper,
            IViewModelMapper<Product, AllProductsViewModel> productMapper,
            IViewModelMapper<Category, CategoryViewModel> categoryMapper,
            IViewModelMapper<Supplier, SupplierViewModel> supplierMapper)
        {
            this.userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
            this.productMapper = productMapper ?? throw new ArgumentNullException(nameof(productMapper));
            this.categoryMapper = categoryMapper ?? throw new ArgumentNullException(nameof(categoryMapper));
            this.supplierMapper = supplierMapper ?? throw new ArgumentNullException(nameof(supplierMapper));
        }

        public AdminViewModel MapFrom(IReadOnlyCollection<ApplicationUser> entity)
        {
            return new AdminViewModel
            {
                Users = entity.Select(this.userMapper.MapFrom).ToList()
            };
        }

        public AdminViewModel MapFrom(IReadOnlyCollection<Product> entity)
        {
            return new AdminViewModel
            {
                Products = entity.Select(this.productMapper.MapFrom).ToList(),
            };
        }

        public AdminViewModel MapFrom(IReadOnlyCollection<Category> entity)
        {
            return new AdminViewModel
            {
                Products = entity.SelectMany(t => t.Products,
                                            (_, p) => this.productMapper.MapFrom(p))
                                 .ToList(),
                Categories = entity.Select(this.categoryMapper.MapFrom).ToList()
            };
        }


        public AdminViewModel MapFrom(IReadOnlyCollection<Supplier> entity)
        {
            return new AdminViewModel
            {
                Suppliers = entity.Select(this.supplierMapper.MapFrom).ToList(),
            };
        }
    }
}
