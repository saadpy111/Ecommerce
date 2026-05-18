using Discount.Core.Repositories;
using Discount.Infrastructure.Context;
using Discount.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Infrastructure.DependencyInjection
{
    public static class DiscountInfraDependencyInjection
    {
        public static IServiceCollection AddDiscountInfraDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
             services.AddDbContext<DiscountDbContext>(options =>
              options.UseNpgsql(
             configuration.GetConnectionString("PostgressConnection")));
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            return services;
        }
    }
}
