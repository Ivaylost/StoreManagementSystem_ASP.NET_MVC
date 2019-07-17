using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public string IdentificationalNumber { get; set; }

        public string RespresentedBy { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

    }
}
