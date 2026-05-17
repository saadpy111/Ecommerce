using Discount.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.Infrastructure.Context
{

    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
