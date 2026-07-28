using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderDbContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database :{typeof(OrderDbContext).Name} seeded!");
            }
        }

        public static IEnumerable<Order.Core.Entities.Order> GetOrders()
        {
            return new List<Order.Core.Entities.Order> {
                new()
                {
                    UserName="SaadAhmed",
                    FirstName="Saad",
                    LastName="Ahmed",
                    EmailAddress="Saad@eCommerce.net",
                    AddressLine="Cairo",
                    Country="Egypt",
                    TotalPrice=750,
                    State="EG",
                    ZipCode="71111",
                    CardName="Visa",
                    CardNumber="1234567890123456",
                    CreatedBy="Saad",
                    Expiration="12/26",
                    Cvv="123",
                    PaymentMethod=1,
                    LastModifiedBy="Saad",
                    LastModifiedDate=new DateTime()
                }
            };
        }
    }
}
