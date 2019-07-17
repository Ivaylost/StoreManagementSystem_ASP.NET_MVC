using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services;
using StoreManagementSystemWeb.Test.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Test.SupplierServiceTests
{
    [TestClass]
    public class GetSupplier_Should
    {
        [TestMethod]
        public void Throw_Agument_Exception_Supplier_DoesntExists()
        {
            var options = TestUtils.GetOptions(nameof(Throw_Agument_Exception_Supplier_DoesntExists));

            using (var assertContext = new ApplicationDbContext(options))
            {
                var sut = new SupplierService(assertContext);

                var ex = Assert.ThrowsException<ArgumentException>(() => sut.GetSupplier("Tosho"));
                Assert.AreEqual($"Supplier Tosho does not exist", ex.Message);
            }
        }


        [TestMethod]
        public void Succeed_If_SupplierExists()
        {
            var options = TestUtils.GetOptions(nameof(Succeed_If_SupplierExists));
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

                var supplier = sut.GetSupplier("Tosho");

                Assert.AreEqual(supplier.SupplierName, "Tosho");
                Assert.AreEqual(supplier.Address, "Sofia adress");
                Assert.AreEqual(supplier.IdentificationNumber, "1010101010");
                Assert.AreEqual(supplier.PhoneNumber, "0872828828");
                Assert.AreEqual(supplier.RepresentedBy, "Pesho");
            }

        }
    }

}
