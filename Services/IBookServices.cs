using Entities;

namespace Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> getBooksAsync();
    }
}