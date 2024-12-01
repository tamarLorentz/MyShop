using MyShop;

namespace Services
{
    public interface IUserServices
    {
        int CheckPassword(string password);
        void Delete(int id);
        IEnumerable<string> Get();
        string Get(int id);
        Task<User> Post(User user);
        Task<User> PostLogIn(string userName, string password);
        void Put(int id, User user);
    }
}