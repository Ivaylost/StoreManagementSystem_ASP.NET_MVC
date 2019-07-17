using Microsoft.EntityFrameworkCore;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagementSystemWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Product CreateProduct(string producName, int categoryId, int availableQuantity, decimal buyPrice,
                                        decimal sellPrice, string picture)
        {
            if (this.context.Products.Any(p => p.ProductName == producName))
            {
                throw new ArgumentException($"Product {producName} already exists");
            }

            var category = this.context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                throw new ArgumentException($"Category {categoryId} does not exist");
            }

            var product = new Product()
            {
                ProductName = producName,
                Category = category,
                AvailableQuantity = availableQuantity,
                BuyPrice = buyPrice,
                SellPrice = sellPrice,
                Picture = picture
            };


            this.context.Products.Add(product);
            this.context.SaveChanges();

            return product;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            return this.context.Products
                .ToList();
        }

        public IReadOnlyCollection<Category> GetAllProductsWithCategories()
            => this.context.Categories.Include(c => c.Products).ToList();

        public IReadOnlyCollection<Category> GetAllProductsInCategory(string categoryName)
        {
            if (categoryName == null || categoryName == "")
            {
                return GetAllProductsWithCategories();
            }
            return this.context.Categories.Include(c => c.Products)
                                        .Where(p => p.CategoryName == categoryName)
                                        .ToList();
        }

        public IReadOnlyList<Product> GetProductWithCategories()
           => this.context.Products.Include(t => t.Category)
            .OrderByDescending(P => P.Id)
            .ToList();

        public Product GetProductById(int id)
           => this.context.Products.Include(t => t.Category)
            .FirstOrDefault(p => p.Id == id);


        public IDictionary<string, List<Product>> GetCategoryWithListOfProducts()
        {
            Dictionary<string, List<Product>> categoryProductDict = new Dictionary<string, List<Product>>();
            var list = this.GetProductWithCategories();
            foreach (var item in list)
            {
                if (!categoryProductDict.ContainsKey(item.Category.CategoryName))
                {
                    categoryProductDict.Add(item.Category.CategoryName, new List<Product>());
                }

                if (categoryProductDict[item.Category.CategoryName].Count < 2)
                {
                    categoryProductDict[item.Category.CategoryName].Add(item);
                }
            }
            return categoryProductDict;
        }



    }
}
