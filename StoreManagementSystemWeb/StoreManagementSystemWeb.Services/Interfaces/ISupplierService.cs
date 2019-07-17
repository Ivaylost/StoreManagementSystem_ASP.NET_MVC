using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Services.Interfaces
{
    public interface ISupplierService
    {
        Supplier CreateSupplier(string supplierName, string identificationNumber, string representedBy, string companyAddress, string phoneNumber);
        Supplier GetSupplier(string supplierName);
        IReadOnlyCollection<Supplier> GetAllSuppliers();
        ProductSupplier AddSupplier(int productId, int supplierId);

    }
}
