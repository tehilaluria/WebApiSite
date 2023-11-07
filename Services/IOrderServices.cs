using Entities;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> AddOrderAsync(Order order);
    }
}