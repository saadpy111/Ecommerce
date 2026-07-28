using Order.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Core.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order.Core.Entities.Order>
    {
        Task<IEnumerable<Order.Core.Entities.Order>> GetOrdersByUserName(string userName);
    }
}
