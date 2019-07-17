using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagementSystemWeb.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Order CreateOrder(string userId, IReadOnlyCollection<ProductShoppingCart> productCarts)
        {

            var user = this.context.Users
                .FirstOrDefault(c => c.Id == userId);

           
            var order = new Order()
            {
                ApplicationUserId = userId,
                OrderDate = DateTime.Now,

            };

            this.context.Orders.Add(order);

            foreach (var item in productCarts)
            {
                var orderProduct = new OrderProduct
                {
                    ProductId = item.ProductId,
                    OrderId=order.Id,
                    Quantity=item.Quantity
                };
                this.context.OrderProducts.Add(orderProduct);
            }

            this.context.SaveChanges();

            return order;
        }

 
    }
}
