using Microsoft.EntityFrameworkCore;
using Entites;
using System.Runtime.InteropServices;
using System.Text.Json;
namespace Resources
{
    public class UserResources : IUserResources
    {
        
        ApiManagerContext context;
        public UserResources(ApiManagerContext apiManagerContext)
        {
            context = apiManagerContext;
        }




        public async Task<User> Get(int id)

        {
            return await context.Users.FindAsync(id);
        }


        public async Task<User> Post(User user)
        {
            var res = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
           // return res;
      }

        public async Task<User> PostLogIn(string userName, string password)
        {
        
            User userFind = await context.Users.FirstOrDefaultAsync(user => user.UserName == userName && user.Password == password);
            return userFind;
        }

        public async Task<User> Put(int id, User user)
        {
            user.Id = id;
         context.Users.Update(user);
            await  context.SaveChangesAsync();
            return user;

           
        }


      
    }
}



