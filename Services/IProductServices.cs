
using Entites;

namespace Services
{
    public interface IProductServices
    {
       
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
       
    }
}