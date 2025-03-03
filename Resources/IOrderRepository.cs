using Entites;

namespace Repository
{
    public interface IOrderRepository
    {
       
        
        Task<Order> Get(int id);
        Task<Order> Post(Order order);
       
    }
}