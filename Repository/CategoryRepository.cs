using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public  class CategoryRepository : ICategoryRepository
    {
        private readonly BookStore325569796Context _BookStore325569796Context;
        public CategoryRepository(BookStore325569796Context BookStore325569796Context)
        {
            _BookStore325569796Context = BookStore325569796Context;

        }

        public async Task<IEnumerable<Category>> getCategoriesAsync()
        {
            return await _BookStore325569796Context.Categories.ToListAsync();
        }
    }
}
