using Entities;

namespace Repositories
{
    public interface IRateRepository
    {
        Task InsertRating(Rating rating);
    }
}