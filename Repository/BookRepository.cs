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
        private readonly BookStore325569796Context _BookStore325569796Context;
        public BookRepository(BookStore325569796Context BookStore325569796Context)
        {
            _BookStore325569796Context = BookStore325569796Context;

        }
        public async Task<IEnumerable<Book>> getBooksAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _BookStore325569796Context.Books.Where(book =>
          (desc == null ?(true) : (book.BookName.Contains(desc)))
          && (minPrice == null ? (true) : (book.Price >= minPrice))
          && (maxPrice == null ? (true) : (book.Price <= maxPrice))
          && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(book.CategoryId))))
          .OrderBy(book => book.Price).Include(b => b.Category);
            List<Book> NewBooks = await query.ToListAsync();
            return NewBooks;
        }
        public async Task<IEnumerable<Book>> GetBooksById(int[] booksId)
        {
            var query = _BookStore325569796Context.Books.Where(b => booksId.Contains(b.BookId));
            return await query.ToListAsync();
        }

    }
}
