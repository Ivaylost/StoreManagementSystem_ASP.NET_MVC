using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public class ProductViewModelMapper : IViewModelMapper<Product, ProductViewModel>
    {
        public ProductViewModel MapFrom(Product entity)
       => new ProductViewModel
       {
           Id = entity.Id,
           ProductName = entity.ProductName,
           BuyPrice = entity.BuyPrice,
           SellPrice = entity.SellPrice,
           Picture=entity.Picture,
           AvailableQuantity = entity.AvailableQuantity,
           CategoryId = entity.Category.Id,
       };
    }
}
