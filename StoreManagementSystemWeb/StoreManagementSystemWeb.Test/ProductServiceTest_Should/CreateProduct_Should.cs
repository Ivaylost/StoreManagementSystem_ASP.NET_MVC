using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManagementSystemWeb.Data;
using System;
using System.Collections.Generic;
using System.Text;
using StoreManagementSystemWeb.Services;
using StoreManagementSystemWeb.Test.Utils;
using StoreManagementSystemWeb.Data.Models;

namespace StoreManagementSystemWeb.Test.ProductServiceTest_Should
{
    [TestClass]
    public class CreateProduct_Should
    {
        [TestMethod]
        public void Throw_Argument_Exception_If_Product_Exists()
        {
            using (var arrangeContext = new ApplicationDbContext(TestUtils.GetOptions(nameof(Throw_Argument_Exception_If_Product_Exists))))
            {
                var sut = new ProductService(arrangeContext);

                var product = new Product()
                {
                    ProductName = "iPhone",
                    CategoryId=1,
                    BuyPrice = (decimal)1000,
                    SellPrice = (decimal)1200,
                    AvailableQuantity = 100,
                    Picture="picture"
                };

                arrangeContext.Products.Add(product);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new ApplicationDbContext(TestUtils.GetOptions(nameof(Throw_Argument_Exception_If_Product_Exists))))
            {
                var sut = new ProductService(assertContext);

                List<Supplier> suppliers = new List<Supplier>();

                suppliers.Add(new Supplier()
                {
                    SupplierName = "Gosho",
                    IdentificationNumber = "10101010",
                    Address = "sofia",
                    RepresentedBy = "pesho",
                    PhoneNumber = "087282888"
                });

                var ex = Assert.ThrowsException<ArgumentException>(() => sut.CreateProduct("iPhone", 1, 100, (decimal)1000, (decimal)1200, "picture"));
                Assert.AreEqual($"Product iPhone already exists", ex.Message);
            }
        }

        [TestMethod]
        public void Throw_Argument_Exception_If_Category_Doesnt_exists()
        {
            using (var assertContext = new ApplicationDbContext(TestUtils.GetOptions(nameof(Throw_Argument_Exception_If_Category_Doesnt_exists))))
            {
                var sut = new ProductService(assertContext);
                List<Supplier> suppliers = new List<Supplier>();

                suppliers.Add(new Supplier()
                {
                    SupplierName = "Gosho",
                    IdentificationNumber = "1010101010",
                    Address = "sofia",
                    RepresentedBy = "pesho",
                    PhoneNumber = "087282888"
                });


                var ex = Assert.ThrowsException<ArgumentException>(() => sut.CreateProduct("iPhone", 1, 100, (decimal)1000, (decimal)1200, "picture"));
                Assert.AreEqual($"Category 1 does not exist", ex.Message);
            }
        }

        [TestMethod]
        public void Succeed_When_CategoryExists()
        {
            using (var arrangeContext = new ApplicationDbContext(TestUtils.GetOptions(nameof(Succeed_When_CategoryExists))))
            {
                var sut = new ProductService(arrangeContext);


                var category = new Category
                {
                    CategoryName = "Clothes",
                    CreatedOn = DateTime.Now

                };


                arrangeContext.Categories.Add(category);
                arrangeContext.SaveChanges();


            }
            using (var assertContext = new ApplicationDbContext(TestUtils.GetOptions(nameof(Succeed_When_CategoryExists))))
            {
                var sut = new ProductService(assertContext);
                List<Supplier> suppliers = new List<Supplier>();


                var supplier = new Supplier
                {
                    SupplierName = "Gosho",
                    IdentificationNumber = "1010101010",
                    Address = "sofia",
                    RepresentedBy = "pesho",
                    PhoneNumber = "087282888"
                };

                suppliers.Add(supplier);

                var product = sut.CreateProduct("TestProduct", 1, 100, (decimal)1.20, (decimal)1.30, "picture");

                Assert.AreEqual("TestProduct", product.ProductName);
                Assert.AreEqual(1, product.Category.Id);
                Assert.AreEqual(100, product.AvailableQuantity);
                Assert.AreEqual((decimal)1.20, product.BuyPrice);
                Assert.AreEqual((decimal)1.30, product.SellPrice);
                Assert.AreEqual("picture", product.Picture);

            }
        }
    }
}
