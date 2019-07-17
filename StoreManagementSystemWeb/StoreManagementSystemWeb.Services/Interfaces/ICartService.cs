using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Services.Interfaces
{
    public interface ICartService
    {
        ShoppingCart CreateCart(string UserId);

        ProductShoppingCart AddProduct(int productId, int shoppingCartId, int quantity);

        void ClearCart(int cartId);

        List<int> GetProductsIds(int cartId);

        List<int> productQuontities(int cartId);

        List<Product> GetProductsWithIds(List<int> productIds);

        ShoppingCart GetCartByUserId(string userId);

        List<ProductShoppingCart> GetProductShoppingCartsById(int cartId);


    }
}
