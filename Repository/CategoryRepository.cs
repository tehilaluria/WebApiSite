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
        private readonly Library214773780Context _Library214773780Context;
        public CategoryRepository(Library214773780Context Library214773780Context)
        {
            _Library214773780Context = Library214773780Context;

        }

        public async Task<IEnumerable<Category>> getCategoriesAsync()
        {
            return await _Library214773780Context.Categories.ToListAsync();
        }
    }
}
