using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Models;
using StoreManagementSystemWeb.Services.Interfaces;

namespace StoreManagementSystemWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> usermanager;

        public ProductController(UserManager<ApplicationUser> usermanager, IProductService productService, ICartService cartService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            this.usermanager = usermanager ?? throw new ArgumentNullException(nameof(usermanager));
        }

        public IActionResult Details()
        {
            return View();
        }

        [Route("Product/GetProductsByCategoryId/{id?}")]
        public IActionResult GetProductsByCategoryId(string id)
        {
            var modelViewProduct = new ProductsViewModel
            {
                ImportedCategories = productService.GetAllProductsInCategory(id)
            };
            return View(modelViewProduct);
        }

        [HttpGet]
        [Route("Product/Details/{id?}")]
        public IActionResult Details(int id)
        {
            var modelViewDetails = new DetailsViewModels
            {
                Product = productService.GetProductById(id),
                Quantity = productService.GetProductById(id).AvailableQuantity
            };

            if (!this.ModelState.IsValid)
            {
                return View(modelViewDetails);
            }
            return View("Details", modelViewDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(DetailsViewModels modelViewDetails)
        {

            if (!this.ModelState.IsValid || modelViewDetails.Quantity > productService.GetProductById(modelViewDetails.ProductId).AvailableQuantity)
            {
                modelViewDetails.Quantity = productService.GetProductById(modelViewDetails.ProductId).AvailableQuantity;
                modelViewDetails.Product = productService.GetProductById(modelViewDetails.ProductId);
                return View(modelViewDetails);
            }

            var userId = this.usermanager.GetUserId(HttpContext.User);

            var cart = this.cartService.GetCartByUserId(userId);

            if (cart != null)
            {
                var productCarts = this.cartService.GetProductShoppingCartsById(cart.Id);
                foreach (var product in productCarts)
                {
                    if (product.ProductId == modelViewDetails.ProductId)
                    {
                        ViewData["Message"] = "The product already exist in your basket!";
                        modelViewDetails.Product = productService.GetProductById(modelViewDetails.ProductId);
                        return View(modelViewDetails);
                    }
                }
            }
            return RedirectToAction("AddToCart", "ShoppingCart", modelViewDetails);
        }
    }
}