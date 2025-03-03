
using Entites;

namespace Repository
{
    public interface IProductRepository
    {
      
        Task<IEnumerable<Product>> Get(int? minPrice, int? maxPrice, int?[] categoryIds, string? desc);
        Task<Product> Get(int id);
        
    }
}