using Entites;

namespace Resources
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
    }
}