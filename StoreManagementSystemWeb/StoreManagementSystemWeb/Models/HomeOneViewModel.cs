using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Models
{
    public class HomeOneViewModel
    {
        public IReadOnlyList<Product> Products { get; set; }

        public IDictionary<string, List<Product>> CategoryProductDict { get; set; }

        public string IphoneCategory { get; set; }
    }
}
