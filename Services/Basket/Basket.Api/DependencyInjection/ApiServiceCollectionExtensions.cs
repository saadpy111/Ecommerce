using Basket.Application.DependencyInjection;
using Basket.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Basket.Api.DependencyInjection
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Basket Api",
                    Contact = new OpenApiContact
                    {
                        Email = "saadahmadpy@gmail.com",
                        Name = "Saad Ahmed",
                    },
                    Description = "Basket Api service in microservice ecommerce system.",
                    Version = "V1"
                });
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1.0);
            });

            services.AddPreServices(configuration);
            return services;
        }

        public static IServiceCollection AddPreServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);

            return services;
        }
    }
}
