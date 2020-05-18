using GetACam.Data;
using GetACam.Service.Categories;
using GetACam.Service.Products;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GetACam.Service.Infrastructure
{
    public static class DependecyMapper
    {
        public static IServiceCollection MapDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<GetACamContext>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ICategoryService, CategoryService>();

            return serviceCollection;
        }
    }
}
