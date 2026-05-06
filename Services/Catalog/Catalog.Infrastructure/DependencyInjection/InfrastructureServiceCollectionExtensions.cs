using Microsoft.Extensions.DependencyInjection;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Data.Contexts;

namespace Catalog.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, CatalogRepository>();
            services.AddScoped<IProductRepository, CatalogRepository>();
            services.AddScoped<ITypeRepository, CatalogRepository>();
            services.AddScoped<ICatalogContext, CatalogContext>();

            return services;
        }
    }
}
