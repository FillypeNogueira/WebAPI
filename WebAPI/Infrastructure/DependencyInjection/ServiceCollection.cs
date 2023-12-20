using WebAPI.Persistence.Repositores;
using WebAPI.Persistence.Repositores.Interface;
using WebAPI.Services;
using WebAPI.Services.Interface;

namespace WebAPI.Infrastructure.DependencyInjection
{
    public static class ServiceCollection
    {
        public static void AddScopedDI(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
