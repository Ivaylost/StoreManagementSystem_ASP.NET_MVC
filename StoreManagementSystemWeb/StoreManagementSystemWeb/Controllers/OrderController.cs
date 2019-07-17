using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;

namespace StoreManagementSystemWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(UserManager<ApplicationUser> usermanager, 
            IOrderService orderService,
            ICartService cartService)
        {
            this.usermanager = usermanager ?? throw new ArgumentNullException(nameof(usermanager));
            this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            this.cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }


        public IActionResult Create()
        {
            var userId = this.usermanager.GetUserId(HttpContext.User);

            var cart = this.cartService.GetCartByUserId(userId);

            var productCarts = this.cartService.GetProductShoppingCartsById(cart.Id);

            this.orderService.CreateOrder(userId, productCarts);

            return RedirectToAction("ClearCart", "ShoppingCart");
        }
    }
}