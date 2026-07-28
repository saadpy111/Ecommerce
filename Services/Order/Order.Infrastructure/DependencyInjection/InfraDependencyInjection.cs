using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Core.Repositories;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.DependencyInjection
{
    public static class InfraDependencyInjection 
    {
        public static IServiceCollection AddInfraDI(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(
             configuration.GetConnectionString("OrderingConnectionString"),
             sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())
             );
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }

    }
}
