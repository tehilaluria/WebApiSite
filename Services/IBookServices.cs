using Entities;

namespace Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> getBooksAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}