
using Entites;

namespace Services
{
    public interface IProductServices
    {
       
        Task<IEnumerable<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc);
        Task<Product> Get(int id);
       
    }
}