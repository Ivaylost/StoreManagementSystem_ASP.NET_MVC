using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Models;
using StoreManagementSystemWeb.Services.Interfaces;

namespace StoreManagementSystemWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly ICartService cartService;

        public ShoppingCartController(ICartService cartService,
            UserManager<ApplicationUser> usermanager,
            IProductService productService,
            IUserService userService)
        {
            this.cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            this.usermanager = usermanager ?? throw new ArgumentNullException(nameof(usermanager));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
            
        //TODO
        public IActionResult ShoppingCart()

        {
            var userId = usermanager.GetUserId(HttpContext.User);

            var cart = this.cartService.GetCartByUserId(userId);

            if (cart == null)
            {

                var shoppingCart = this.cartService.CreateCart(userId);
                cart = this.cartService.GetCartByUserId(userId);
            }

            var productIds = this.cartService.GetProductsIds(cart.Id);

            var productQuontity = this.cartService.productQuontities(cart.Id);

            var result = this.cartService.GetProductsWithIds(productIds);



            var model = new ShoppingCartViewModel
            {
                ImportedProducts = result,
                ProductsQuantity = productQuontity
                
            };
            return View(model);
        }


        public IActionResult AddToCart(DetailsViewModels modelViewDetails)
        {
            var product = this.productService.GetProductById(modelViewDetails.ProductId);
            var userId = usermanager.GetUserId(HttpContext.User);

            var user = this.userService.GetUserById(userId);

            var cart = this.cartService.GetCartByUserId(userId);


            if (cart == null)
            {
                if (userId == null)
                {
                    return RedirectToAction("Login", "AccountController");
                }

                var shoppingCart = this.cartService.CreateCart(userId);
                cart= this.cartService.GetCartByUserId(userId);
            }

            var cartId = cart.Id;

            this.cartService.AddProduct(product.Id, cartId, modelViewDetails.Quantity);


            return RedirectToAction("ShoppingCart", "ShoppingCart");
        }

        public IActionResult ClearCart()
        {
            var userId = usermanager.GetUserId(HttpContext.User);

            var cart = this.cartService.GetCartByUserId(userId);

            this.cartService.ClearCart(cart.Id);

            return RedirectToAction("ShoppingCart", "ShoppingCart");
        }


    }
}