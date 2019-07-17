using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
