using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<ProductShoppingCart> ProductShoppingCart { get; set; }

    }
}
