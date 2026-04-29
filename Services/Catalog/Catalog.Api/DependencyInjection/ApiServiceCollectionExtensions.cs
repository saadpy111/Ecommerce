using Catalog.Application.DependencyInjection;
using Catalog.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;


namespace Catalog.Api.DependencyInjection
{
    public static class ApiServiceCollectionExtensions
    {

        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // Register MVC controllers
            services.AddControllers();

            // Register Swagger generation and endpoint explorer
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
                {
                    Title = "Catalog Api",
                    Contact = new OpenApiContact
                    {
                        Email = "saadahmadpy@gmail.com",
                        Name = "Saad Ahmed",

                    },
                    Description = "Catalog Api service in microservice ecommerce system .",
                    Version = "V1"

                });


            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1.0);
            });
             


            services.AddPreServices();
            return services;
        }
        public static IServiceCollection AddPreServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices();

            return services;
        }
    }
}
