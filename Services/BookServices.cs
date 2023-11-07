using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookServices : IBookServices
    {
        IBookRepository _bookRepository;

        public BookServices(IBookRepository ibookRepository)
        {
            _bookRepository = ibookRepository;
        }


        public async Task<IEnumerable<Book>> getBooksAsync()
        {
            return await _bookRepository.getBooksAsync();
        }
    }
}
