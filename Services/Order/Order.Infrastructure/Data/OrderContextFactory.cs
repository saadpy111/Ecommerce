using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Data
{
    public class OrderContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();

            string con = "Server=localhost;Database=OrderDb2;User Id=sa;Password=P@ssw0rd123;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(con);
            return new OrderDbContext(optionsBuilder.Options);
        }
    }
}
