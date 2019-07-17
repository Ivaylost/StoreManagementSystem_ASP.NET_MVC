using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal SellPrice { get; set; }

        public string Picture { get; set; }

        public int AvailableQuantity { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
