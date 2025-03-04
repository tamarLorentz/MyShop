using Entites;

namespace Repository
{
    public interface ICategoryRepository
    {
        // Get all categories
        Task<IEnumerable<Category>> Get();
    }
}