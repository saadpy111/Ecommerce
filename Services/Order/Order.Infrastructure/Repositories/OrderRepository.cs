using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using Order.Core.Repositories;
using Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order.Core.Entities.Order>, IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Core.Entities.Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                .Where(o => o.UserName == userName)
                .ToListAsync();

            return orderList;
        }
    }
}
