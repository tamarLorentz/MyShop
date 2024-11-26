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


    public User Post(User user)
    {
        //check password strength
        return userResources.Post(user);


    }

    public User PostLogIn(string userName, string password)
    {

        return userResources.PostLogIn(userName, password);
    }

    public void Put(int id, User user)
    {  //check password strength
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
