using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services;
using StoreManagementSystemWeb.Test.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Test.ProductServiceTest_Should
{
    [TestClass]
    public class GetAllProducts_Should
    {
        [TestMethod]
        public void Return_All_Product()
        {
            using (var arrangeContext = new ApplicationDbContext(TestUtils.GetOptions(nameof(Return_All_Product))))
            {
                var sut = new ProductService(arrangeContext);

                var product = new Product()
                {
                    ProductName = "TestProduct",
                    CategoryId = 1,
                    BuyPrice = (decimal)1.20,
                    SellPrice = (decimal)1.30,
                    AvailableQuantity = 100,
                    Picture = "picture"
                };

                arrangeContext.Products.Add(product);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new ApplicationDbContext(TestUtils.GetOptions(nameof(Return_All_Product))))
            {
                var sut = new ProductService(assertContext);

                var product = sut.GetAllProducts();
                Assert.AreEqual(1, product.Count);
            }

        }
    }
}
