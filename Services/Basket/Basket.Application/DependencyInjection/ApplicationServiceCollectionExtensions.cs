using System.Reflection;
using Basket.Application.Features.Basket.Queries.GetBasketByUserName;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof( GetBasketByUserNameQueryRequest).Assembly));

            return services;
        }
    }
}
