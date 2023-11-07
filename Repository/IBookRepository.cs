using Entities;

namespace Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> getBooksAsync();
    }
}