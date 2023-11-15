using Entities;

namespace Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> getBooksAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}