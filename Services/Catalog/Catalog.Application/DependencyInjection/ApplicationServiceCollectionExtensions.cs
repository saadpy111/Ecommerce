using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using Catalog.Application.Features.Products.Queries.GetAllProducts;
using Catalog.Application.Mappers;

namespace Catalog.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR handlers from the Application layer
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllProductsQueryHandler).Assembly));

            // Register AutoMapper profiles from the Application layer
            services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

            return services;
        }
    }
}
