using Entites;
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



    public Task<User> Get(int id)
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

    public Task<User> Put(int id, User user)
    {
        int passwordScore = CheckPassword(user.Password);
        if (passwordScore > 3)
        {
            return userResources.Put(id, user);
          
        }
        else
            return null;


    }


  
    public int CheckPassword(string password)
    {
        return Zxcvbn.Core.EvaluatePassword(password).Score;
    }
}
