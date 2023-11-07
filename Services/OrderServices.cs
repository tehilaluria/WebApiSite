using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        IOrderRepository _orderRepository;

        public OrderServices(IOrderRepository iorderRepository)
        {
            _orderRepository = iorderRepository;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            return await _orderRepository.AddOrderAsync(order);

        }

    }
}
