using StoreManagementSystemWeb.Areas.Administration.Models;
using System.Collections.Generic;

namespace StoreManagementSystemWeb.Models
{
    public class HomeViewModel
    {
        public IReadOnlyList<UserViewModel> Users { get; set; }

        //public IReadOnlyList<Product> Products { get; set; }
    }
}