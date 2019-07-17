using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagementSystemWeb.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext context;

        public SupplierService(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Supplier CreateSupplier(string supplierName, string identificationNumber, string representedBy,
                                    string companyAddress, string phoneNumber)
        {
            if (this.context.Suppliers.Any(c => c.SupplierName == supplierName))

            {
                throw new ArgumentException($"Supplier with name {supplierName} already exists");
            }

            var supplaier = new Supplier()
            {
                SupplierName = supplierName,
                IdentificationNumber = identificationNumber,
                RepresentedBy = representedBy,
                Address = companyAddress,
                PhoneNumber = (phoneNumber == "" ? null : phoneNumber)
            };

            this.context.Suppliers.Add(supplaier);
            this.context.SaveChanges();

            return supplaier;
        }

        public Supplier GetSupplier(string supplierName)
        {
            var supplier = this.context.Suppliers
                .FirstOrDefault(c => c.SupplierName == supplierName);

            if (supplier == null)
            {
                throw new ArgumentException($"Supplier {supplierName} does not exist");
            }

            return supplier;
        }

        public IReadOnlyCollection<Supplier> GetAllSuppliers()
        {
            return this.context.Suppliers
               .ToList();
        }

        public ProductSupplier AddSupplier(int productId,int supplierId)
        {
            var productSupplier = new ProductSupplier()
            {
               ProductId=productId,
               SupplierId=supplierId
            };
            this.context.ProductSuppliers.Add(productSupplier);
            this.context.SaveChanges();
            return productSupplier;
        }

    }
}
