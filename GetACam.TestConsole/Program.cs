using GetACam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GetACam.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
			ServiceProvider serviceProvider = new ServiceCollection()
				.AddDbContext<GetACamContext>()
				.BuildServiceProvider();

			using (var scope = serviceProvider.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<GetACamContext>();
				context.Database.Migrate();
				Seed.SeedCategories(context);
				Seed.SeedProducts(context);
				Seed.SeedOrders(context);
				Seed.SeedOrderItems(context);
				Seed.SeedOrderDetails(context);
			}

			Console.WriteLine("Data has be seeded.");


		}
    }
}
