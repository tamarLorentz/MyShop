using Entites;

namespace Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> Get();
    }
}