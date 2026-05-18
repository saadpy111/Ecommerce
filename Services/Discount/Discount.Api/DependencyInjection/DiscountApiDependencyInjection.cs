using Discount.Grpc.Protos;
using Discount.Infrastructure.Context;
using Discount.Infrastructure.DependencyInjection;
using Discount.Application.DependencyInjection;
 
namespace Discount.Api.DependencyInjection
{
    public static class DiscountApiDependencyInjection
    {
        public static IServiceCollection AddDiscountApiDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDiscountInfraDependencyInjection(configuration);
            services.AddApplicationServices();
            return services;
        }
    }
}
