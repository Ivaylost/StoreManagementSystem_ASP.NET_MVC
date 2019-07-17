using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Services.Interfaces
{
    public interface ICategoryService
    {
        Category CreateCategory(string name);

        IReadOnlyCollection<Product> GetCategoryById(string id);

        string GetProfitFromCategory(string categoryName);

        IReadOnlyCollection<Category> GetAllCategories();

    }
}
