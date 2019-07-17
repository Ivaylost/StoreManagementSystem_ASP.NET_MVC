using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal BuyPrice { get; set; }
        
        public decimal SellPrice { get; set; }

        public string Picture { get; set; }

        public int AvailableQuantity { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderProduct> OrderProduct { get; set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }

        public ICollection<ProductShoppingCart> ProductShoppingCart { get; set; }

    }
}
