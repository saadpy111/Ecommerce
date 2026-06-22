using System.Reflection;
using Basket.Application.Features.Basket.Queries.GetBasketByUserName;
using Basket.Application.GrpcServices;
using Discount.Grpc.Protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof( GetBasketByUserNameQueryRequest).Assembly));
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                (cfg =>
                {
                    cfg.Address = new Uri(configuration["DiscountSettings:DiscountUrl"]);
                });
            services.AddScoped<DiscountGrpcService>();
            return services;
        }
    }
}
