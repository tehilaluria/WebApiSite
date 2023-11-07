using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Library214773780Context _Library214773780Context;
        public BookRepository(Library214773780Context Library214773780Context)
        {
            _Library214773780Context = Library214773780Context;

        }
        public async Task<IEnumerable<Book>> getBooksAsync()
        {
            return await _Library214773780Context.Books.ToListAsync();
        }

    }
}
