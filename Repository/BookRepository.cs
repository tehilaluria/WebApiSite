using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Library214773780Context _Library214773780Context;
        public BookRepository(Library214773780Context Library214773780Context)
        {
            _Library214773780Context = Library214773780Context;

        }
        public async Task<IEnumerable<Book>> getBooksAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _Library214773780Context.Books.Where(book =>
          (desc == null ?(true) : (book.BookName.Contains(desc)))
          && (minPrice == null ? (true) : (book.Price >= minPrice))
          && (maxPrice == null ? (true) : (book.Price <= maxPrice))
          && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(book.CategoryId))))
          .OrderBy(product => product.Price);
            List<Book> NewBooks = await query.ToListAsync();
            return NewBooks;
        }

    }
}
