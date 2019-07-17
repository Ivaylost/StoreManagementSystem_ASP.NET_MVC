using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Models
{
    public class AdminViewModel
    {
        public IReadOnlyList<UserViewModel> Users { get; set; }

        public IReadOnlyList<AllProductsViewModel> Products { get; set; }

        public IReadOnlyList<CategoryViewModel> Categories { get; set; }

        public IReadOnlyList<SupplierViewModel> Suppliers { get; set; }

        //public ProductViewModel Product { get; set; }

    }
}