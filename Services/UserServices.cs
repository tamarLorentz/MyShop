using MyShop;
using System.Runtime.InteropServices;
using System.Text.Json;
using Resources;
using Zxcvbn;


namespace Services;

public class UserServices : IUserServices
{

    IUserResources userResources;
    public UserServices(IUserResources _userResources)
    {
        userResources = _userResources;
    }

    public IEnumerable<string> Get()
    {
        return userResources.Get();
    }

    public string Get(int id)
    {
        return userResources.Get(id);
    }


    public  Task<User> Post(User user)
    {
        int passwordScore = CheckPassword(user.Password);
        if (passwordScore < 3)
            return null;
        return userResources.Post(user);


    }

    public Task<User> PostLogIn(string userName, string password)
    {

        return userResources.PostLogIn(userName, password);
    }

    public void Put(int id, User user)
    {
        int passwordScore = CheckPassword(user.Password);
        if (passwordScore > 3)
           userResources.Put(id, user);


    }


    public void Delete(int id)
    {
    }
    public int CheckPassword(string password)
    {
        return Zxcvbn.Core.EvaluatePassword(password).Score;
    }
}
