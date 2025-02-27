using Entites;

namespace Resources
{
    public interface IRatingRepository
    {
        Task PostRating(Rating rating);
    }
}