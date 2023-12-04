using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RateRepository:IRateRepository
    {
        private readonly BookStore325569796Context _BookStore325569796Context;
        public RateRepository(BookStore325569796Context BookStore325569796Context)
        {
            _BookStore325569796Context = BookStore325569796Context;

        }
        public async Task InsertRating(Rating rating)
        {
            await _BookStore325569796Context.Ratings.AddAsync(rating);
            await _BookStore325569796Context.SaveChangesAsync();
            
        }
    }
}
