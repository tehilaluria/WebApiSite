using Entities;

namespace Services
{
    public interface IRateServices
    {
        Task InsertRating(Rating rating);
    }
}