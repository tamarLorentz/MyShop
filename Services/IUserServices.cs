using Entites;

namespace Services
{
    public interface IUserServices
    {
        int CheckPassword(string password);
      

        Task<User> Get(int id);
        Task<User> Post(User user);
        Task<User> PostLogIn(string userName, string password);
        Task<User> Put(int id, User user);
    }
}