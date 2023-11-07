using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
    }
}