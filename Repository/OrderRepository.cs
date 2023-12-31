﻿using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStore325569796Context _BookStore325569796Context;
        public OrderRepository(BookStore325569796Context BookStore325569796Context)
        {
            _BookStore325569796Context = BookStore325569796Context;

        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            await _BookStore325569796Context.Orders.AddAsync(order);
            await _BookStore325569796Context.SaveChangesAsync();
            return order;
        }
       
    }
}
