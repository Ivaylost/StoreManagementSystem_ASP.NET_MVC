using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public class AllProductsViewModelMapper: IViewModelMapper<Product, AllProductsViewModel>
    {
        public AllProductsViewModel MapFrom(Product entity)
     => new AllProductsViewModel
     {
         Id = entity.Id,
         ProductName = entity.ProductName,
         BuyPrice = entity.BuyPrice,
         SellPrice = entity.SellPrice,
         Picture = entity.Picture,
         AvailableQuantity = entity.AvailableQuantity,
         CategoryId=entity.CategoryId,
         CategoryName=entity.Category.CategoryName
     };
    }
}
