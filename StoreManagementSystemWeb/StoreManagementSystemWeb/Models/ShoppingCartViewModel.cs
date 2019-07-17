using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Models
{
    public class ShoppingCartViewModel
    {
        public IReadOnlyCollection<Product> ImportedProducts { get; set; }
        public List<int> ProductsQuantity { get; set; }
    }
}
