using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagementSystemWeb.Data.Models;
using System.Collections.Generic;

namespace StoreManagementSystemWeb.Areas.Models
{
    public class AddSupplierViewModel
    {
        public int ProductId { get; set; }
        //public int SupplierId { get; set; }
        public int SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }
    }
}