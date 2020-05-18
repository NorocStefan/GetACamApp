using GetACam.Data;
using GetACam.Data.Entities;
using GetACam.Service.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetACam.Web.Models
{
    public class ShoppingCart
    {
        private readonly GetACamContext getACamContext;

        public string ShoppingCartId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public ShoppingCart(GetACamContext getACamContext)
        {
            this.getACamContext = getACamContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<GetACamContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int quantity)
        {
            var orderItem =
                    getACamContext.OrderItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            if (orderItem == null)
            {
                orderItem = new OrderItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1
                };

                getACamContext.OrderItems.Add(orderItem);
            }
            else
            {
                orderItem.Quantity++;
            }
            getACamContext.SaveChanges();
        }
        public int RemoveFromCart(Product product)
        {
            var orderItem =
                    getACamContext.OrderItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            var localQuantity = 0;

            if (orderItem != null)
            {
                if (orderItem.Quantity > 1)
                {
                    orderItem.Quantity--;
                    localQuantity = orderItem.Quantity;
                }
                else
                {
                    getACamContext.OrderItems.Remove(orderItem);
                }
            }

            getACamContext.SaveChanges();

            return localQuantity;
        }
        public List<OrderItem> GetOrderItems()
        {
            return OrderItems ??
                   (OrderItems =
                       getACamContext.OrderItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList());
        }
        public void ClearCart()
        {
            var orderItems = getACamContext
                .OrderItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            getACamContext.OrderItems.RemoveRange(orderItems);

            getACamContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = getACamContext.OrderItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Quantity).Sum();
            return total;
        }
    }
}
