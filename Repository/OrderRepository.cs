using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Library214773780Context _Library214773780Context;
        public OrderRepository(Library214773780Context Library214773780Context)
        {
            _Library214773780Context = Library214773780Context;

        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            await _Library214773780Context.Orders.AddAsync(order);
            await _Library214773780Context.SaveChangesAsync();
            return order;
        }
    }
}
