using GetACam.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetACam.Data
{
	public class Seed
	{
		//public static void SeedUsers(GetACamContext context)
		//{
		//	if (!context.Users.Any())
		//	{
		//		var usersData = System.IO.File.ReadAllText(@"C:\Users\noroc\Desktop\GetACam.App\GetACam.TestConsole\Seeder\user.json");
		//		var users = JsonConvert.DeserializeObject<List<User>>(usersData);

		//		foreach (var user in users)
		//		{
		//			byte[] passwordHash, passwordSalt;
		//			CreatePasswordHash("password", out passwordHash, out passwordSalt);

		//			user.PasswordHash = passwordHash;
		//			user.PasswordSalt = passwordSalt;
		//			user.EmailAddress = user.EmailAddress.ToLower();
		//			context.Users.Add(user);
					
		//		}
		//		context.SaveChanges();
		//	}
		//}

		private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			};
		}

		public static void SeedOrders(GetACamContext context)
		{
			if (!context.Orders.Any())
			{
				var ordersData = System.IO.File.ReadAllText(@"C:\Users\noroc\Desktop\GetACam.App\GetACam.TestConsole\Seeder\order.json");
				var orders = JsonConvert.DeserializeObject<List<Order>>(ordersData);

				foreach (var order in orders)
				{
					context.Orders.Add(order);
				}
				context.SaveChanges();
			}
		}

		public static void SeedOrderItems(GetACamContext context)
		{
			if (!context.OrderItems.Any())
			{
				var orderItemsData = System.IO.File.ReadAllText(@"C:\Users\noroc\Desktop\GetACam.App\GetACam.TestConsole\Seeder\orderitem.json");
				var orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(orderItemsData);

				foreach (var orderItem in orderItems)
				{
					context.OrderItems.Add(orderItem);
				}
				context.SaveChanges();
			}
		}

		public static void SeedProducts(GetACamContext context)
		{
			if (!context.Products.Any())
			{
				var productsData = System.IO.File.ReadAllText(@"C:\Users\noroc\Desktop\GetACam.App\GetACam.TestConsole\Seeder\product.json");
				var products = JsonConvert.DeserializeObject<List<Product>>(productsData);

				foreach (var product in products)
				{
					context.Products.Add(product);
				}
				context.SaveChanges();
			}
		}

		public static void SeedCategories(GetACamContext context)
		{
			if (!context.Categories.Any())
			{
				var categoriesData = System.IO.File.ReadAllText(@"C:\Users\noroc\Desktop\GetACam.App\GetACam.TestConsole\Seeder\category.json");
				var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesData);

				foreach (var category in categories)
				{
					context.Categories.Add(category);
				}
				context.SaveChanges();
			}
		}

		public static void SeedOrderDetails(GetACamContext context)
		{
			if (!context.OrderDetails.Any())
			{
				var orderDetailsData = System.IO.File.ReadAllText(@"C:\Users\noroc\Desktop\GetACam.App\GetACam.TestConsole\Seeder\orderdetail.json");
				var orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(orderDetailsData);

				foreach (var orderDetail in orderDetails)
				{
					context.OrderDetails.Add(orderDetail);
				}
				context.SaveChanges();
			}
		}
	}
}
