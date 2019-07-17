using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Models;
using StoreManagementSystemWeb.Services.Interfaces;

namespace StoreManagementSystemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService, ApplicationDbContext dbContext)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public IActionResult Index()
        {
            var viewOneModel = new HomeOneViewModel()
            {
                IphoneCategory = "132",
            };
            return View(viewOneModel);
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            return View();
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Categories(string id)
        {
            var importedCategorie = new HomeOneViewModel {
                CategoryProductDict = productService.GetCategoryWithListOfProducts() };

            return View(importedCategorie);
        }

        public IActionResult Products()
        {
            ViewData["Message"] = "Description";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
