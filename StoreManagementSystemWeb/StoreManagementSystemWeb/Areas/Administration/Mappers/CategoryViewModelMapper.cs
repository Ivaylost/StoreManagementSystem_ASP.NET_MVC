using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public class CategoryViewModelMapper: IViewModelMapper<Category, CategoryViewModel>
    {
        public CategoryViewModel MapFrom(Category entity)
     => new CategoryViewModel
     {
         Id = entity.Id,
         CategoryName = entity.CategoryName,
         CreatedOn = entity.CreatedOn,
         Profit = entity.Products
              .Select(s => (s.SellPrice - s.BuyPrice)*s.AvailableQuantity)
              .AsEnumerable()
              .Sum()
              .ToString()
     };
    }
}
