using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystemWeb.Areas.Administration.Mappers;
using StoreManagementSystemWeb.Areas.Models;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;

namespace StoreManagementSystemWeb.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IViewModelMapper<Category, CategoryViewModel> categoryMapper;

        public CategoryController(ICategoryService categoryService,
                        IViewModelMapper<Category, CategoryViewModel> categoryMapper)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.categoryMapper = categoryMapper ?? throw new ArgumentNullException(nameof(categoryMapper));
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return PartialView("AddCategory");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            var category = this.categoryService.CreateCategory(model.CategoryName);

            return RedirectToAction("AllProducts", "Product");
        }
    }
}