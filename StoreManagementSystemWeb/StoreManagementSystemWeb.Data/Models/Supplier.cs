using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public string IdentificationNumber { get; set; }

        public string RepresentedBy { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}
