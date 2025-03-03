using Entites;

namespace Repository
{
    public interface IRatingRepository
    {
        Task PostRating(Rating rating);
    }
}