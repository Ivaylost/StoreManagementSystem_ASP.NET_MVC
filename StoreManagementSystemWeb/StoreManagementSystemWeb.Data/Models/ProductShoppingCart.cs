using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Data.Models
{
    public class ProductShoppingCart
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int ShoppingCartId { get; set; }

        public Product Product { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
