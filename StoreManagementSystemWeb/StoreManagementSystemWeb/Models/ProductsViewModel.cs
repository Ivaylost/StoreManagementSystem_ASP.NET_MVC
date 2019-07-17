using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Models
{
    public class ProductsViewModel
    {
        public IReadOnlyCollection<Category> ImportedCategories { get; set; }
    }
}
