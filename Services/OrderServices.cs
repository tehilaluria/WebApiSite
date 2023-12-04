using Entities;
using Microsoft.Extensions.Logging;
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
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<OrderServices> _logger;
        public OrderServices(IOrderRepository iorderRepository, IBookRepository bookRepository, ILogger<OrderServices> logger)
        {
            _orderRepository = iorderRepository;
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            int[] bookId = new int[order.OrderBooks.Count];
            decimal totalSumFromClient = (decimal)order.OrderSum;

            for (int i = 0; i < order.OrderBooks.Count; i++)
            {
                bookId[i] = (int)order.OrderBooks.ElementAt(i).BookId;
            }

            IEnumerable<Book> listBook = await _bookRepository.GetBooksById(bookId);
            decimal? totalSumFromDb = 0;
            for(var i=0;i<order.OrderBooks.Count;i++)
            {
                totalSumFromDb += listBook.ElementAt(i).Price * order.OrderBooks.ElementAt(i).Quantity;
            }
            if (totalSumFromClient != totalSumFromDb)
                _logger.LogError("the user did something not valid the user tryed still ,the totalSum != orderSum");
            order.OrderSum = (decimal)totalSumFromDb;
            return await _orderRepository.AddOrderAsync(order);

        }

    }
}
