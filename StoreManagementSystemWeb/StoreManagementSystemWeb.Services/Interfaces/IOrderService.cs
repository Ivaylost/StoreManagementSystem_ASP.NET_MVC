using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Services.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(string userId, IReadOnlyCollection<ProductShoppingCart> productCarts);

    }
}
