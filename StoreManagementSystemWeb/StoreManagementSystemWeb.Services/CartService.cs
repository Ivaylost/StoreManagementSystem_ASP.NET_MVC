using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagementSystemWeb.Services
{
    public class CartService: ICartService
    {
        private readonly ApplicationDbContext context;
        private readonly IProductService product;

        public CartService(ApplicationDbContext context, IProductService product)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public List<ProductShoppingCart> GetProductShoppingCartsById(int cartId)
        {
            return this.context.ProductShoppingCarts
               .Where(x => x.ShoppingCartId == cartId)
               .ToList();
        }

        public ShoppingCart GetCartByUserId(string userId)
        {
            return this.context.ShoppingCarts.FirstOrDefault(u => u.ApplicationUserId == userId);
        }

        public List<int> GetProductsIds(int cartId)
        {
            var productIds = this.context.ProductShoppingCarts
                 .Where(x => x.ShoppingCartId == cartId) // filtering goes here
                .Select(x => x.ProductId)
                .Distinct()
                .ToList();

            return productIds;
        }

        public List<int> productQuontities(int cartId)
        {

            var productQuontities = this.context.ProductShoppingCarts
                 .Where(x => x.ShoppingCartId == cartId) // filtering goes here
                .Select(x => x.Quantity)
                .ToList();


            return productQuontities;
        }

        public List<Product> GetProductsWithIds(List<int> productIds)
        {
            var result = this.context.Products
                .Where(x => productIds.Contains(x.Id))
                .ToList();

            return result;
        }

        public void ClearCart(int cartId)
        {

            var productsCarts = this.context.ProductShoppingCarts.Where(p => p.ShoppingCartId == cartId).ToList();

            foreach (var cart in productsCarts)
            {
                var productUpd = product.GetProductById(cart.ProductId);
                productUpd.AvailableQuantity = productUpd.AvailableQuantity - cart.Quantity;
                this.context.ProductShoppingCarts.Remove(cart);
            }

            this.context.SaveChanges();

        }

        public ShoppingCart CreateCart(string UserId)
        {
            var cart = new ShoppingCart()
            {
                ApplicationUserId = UserId
            };

            this.context.ShoppingCarts.Add(cart);
            this.context.SaveChanges();

            return cart;
        }

        public ProductShoppingCart AddProduct(int productId, int shoppingCartId, int quantity)
        {

            var productShoppingCart = new ProductShoppingCart()
            {
                ProductId = productId,
                ShoppingCartId = shoppingCartId,
                Quantity = quantity
            };

            this.context.ProductShoppingCarts.Add(productShoppingCart);
            this.context.SaveChanges();

            return productShoppingCart;
        }
    }
}
