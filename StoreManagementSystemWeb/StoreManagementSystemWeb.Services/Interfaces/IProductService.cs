using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Services.Interfaces
{
    public interface IProductService
    {
        Product CreateProduct(string producName, int categoryId, int availableQuantity, decimal buyPrice,
    decimal sellPrice, string picture);

        IReadOnlyCollection<Product> GetAllProducts();

        IReadOnlyCollection<Category> GetAllProductsWithCategories();

        IReadOnlyCollection<Category> GetAllProductsInCategory(string categoryName);

        IDictionary<string, List<Product>> GetCategoryWithListOfProducts();

        Product GetProductById(int id);
    }
}
