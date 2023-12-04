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
   
    public class RateServices:IRateServices
    {
        private readonly IRateRepository _irateRepository;

        public RateServices( IRateRepository rateRepository)
        {
            _irateRepository = rateRepository;
           
        }

        public async Task InsertRating(Rating rating)
        {

             await _irateRepository.InsertRating(rating);

        }

    }
}
