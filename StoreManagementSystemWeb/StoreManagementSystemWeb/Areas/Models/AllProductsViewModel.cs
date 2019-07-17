using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Models
{
    public class AllProductsViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal SellPrice { get; set; }

        public string Picture { get; set; }

        public int AvailableQuantity { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
