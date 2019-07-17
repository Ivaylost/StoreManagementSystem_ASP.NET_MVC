using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagementSystemWeb.Areas.Administration.Mappers;
using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;

namespace StoreManagementSystemWeb.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ProductController : Controller
    {
        private readonly IHostingEnvironment he;

        private readonly IProductService productService;
        private readonly ICategoryService categoryServive;
        private readonly IViewModelMapper<Product, ProductViewModel> productMapper;
        private readonly IViewModelMapper<IReadOnlyCollection<Category>, AdminViewModel> homeViewModelMapper;

        public ProductController(IProductService productService, IViewModelMapper<Product, ProductViewModel> productMapper,
            IViewModelMapper<IReadOnlyCollection<Category>, AdminViewModel> homeViewModelMapper,
            IHostingEnvironment he,
            ICategoryService categoryServive
            )
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.productMapper = productMapper ?? throw new ArgumentNullException(nameof(productMapper));
            this.homeViewModelMapper = homeViewModelMapper ?? throw new ArgumentNullException(nameof(homeViewModelMapper));
            this.he = he;
            this.categoryServive = categoryServive ?? throw new ArgumentNullException(nameof(categoryServive));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = this.categoryServive.GetAllCategories();

            var model = new ProductViewModel()
            {
                Categories = categories.Select(x => new SelectListItem(x.CategoryName, x.Id.ToString()))
            };


            return View("Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model, IFormFile pic)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }


            try
            {
                if (pic != null)
                {
                    var filename = Path.Combine(he.WebRootPath,"images/",Path.GetFileName(pic.FileName));
                    pic.CopyTo(new FileStream(filename, FileMode.Create));
                    var picturePath = "~/images/" + Path.GetFileName(pic.FileName);

                    var product = this.productService.CreateProduct(model.ProductName, model.Id,
                        model.AvailableQuantity, model.BuyPrice, model.SellPrice, picturePath);
                }


                return RedirectToAction("AllProducts", "Product");
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(model);
            }

        }

        public IActionResult AllProducts()
        {
            var categories = this.productService.GetAllProductsWithCategories();

            var model = this.homeViewModelMapper.MapFrom(categories);

            return View("AllProducts", model);
        }

    }
}