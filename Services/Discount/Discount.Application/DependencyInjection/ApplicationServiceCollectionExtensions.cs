using Discount.Application.Features.Queries.GetDiscount;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Discount.Application.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetDiscountQuery).Assembly));
            services.AddGrpc();
            return services;
        }
    }
}
