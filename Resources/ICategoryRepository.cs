using Entites;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
    }
}