using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Services;
using StoreManagementSystemWeb.Test.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Test.SupplierServiceTests
{
    [TestClass]
    public class AddSupplier_Should
    {
        [TestMethod]
        public void Succeed_If_Supplier_DoesntExist()
        {
            var options = TestUtils.GetOptions(nameof(Succeed_If_Supplier_DoesntExist));

            using (var assertContext = new ApplicationDbContext(options))
            {
                var sut = new SupplierService(assertContext);


                var supplier = sut.AddSupplier(1,1);

                Assert.AreEqual(1, supplier.ProductId);
                Assert.AreEqual(1, supplier.SupplierId);
               
            }

        }
    }
}
