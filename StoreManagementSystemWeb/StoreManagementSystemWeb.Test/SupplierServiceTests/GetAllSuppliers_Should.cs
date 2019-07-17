using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services;
using StoreManagementSystemWeb.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagementSystemWeb.Test.SupplierServiceTests
{
    [TestClass]
    public class GetAllSuppliers_Should
    {
        [TestMethod]
        public void Succeed_When_Suppliers_Exists()
        {
            var options = TestUtils.GetOptions(nameof(Succeed_When_Suppliers_Exists));
            using (var arrangeContext = new ApplicationDbContext(options))
            {
                var sut = new SupplierService(arrangeContext);

                var supplier = new Supplier()
                {
                    SupplierName = "Tosho",
                    Address = "Sofia adress",
                    IdentificationNumber = "1010101010",
                    PhoneNumber = "0872828828",
                    RepresentedBy = "Pesho"

                };

                arrangeContext.Suppliers.Add(supplier);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new ApplicationDbContext(options))
            {
                var sut = new SupplierService(assertContext);

                var suppliers = sut.GetAllSuppliers();

                Assert.IsTrue(suppliers.Any());
            }
        }
    }
}
