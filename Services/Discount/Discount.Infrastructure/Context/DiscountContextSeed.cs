using Discount.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Context
{

    public static class DiscountContextSeed
    {
        public static async Task SeedAsync(DiscountDbContext context)
        {
            if (!await context.Coupons.AnyAsync())
            {
                await context.Coupons.AddRangeAsync(
                    new Coupon
                    {
                        ProductName = "Yonex VCORE Pro 100 A Tennis Racquet (290gm, Strung)",
                        Description = "IPhone Discount",
                        Amount = 500
                    },
                    new Coupon
                    {
                        ProductName = "Babolat Boost D Tennis Racquet (260gm, Strung)",
                        Description = "Samsung Discount",
                        Amount = 300
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
