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

            string con = "Data Source=DESKTOP-VGEBCK1\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer("con");
            return new OrderDbContext(optionsBuilder.Options);
        }
    }
}
