using Entites;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> Get(int id);
        Task<Order> Post(Order order);
    }
}