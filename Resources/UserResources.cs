using Microsoft.EntityFrameworkCore;
using MyShop;
using System.Runtime.InteropServices;
using System.Text.Json;
namespace Resources
{
    public class UserResources : IUserResources
    {
        string pathFile = "M:\\WebAPI\\lesson1\\MyShop\\MyShop\\db.txt";
        ApiManagerContext context;
        public UserResources(ApiManagerContext apiManagerContext)
        {
            context = apiManagerContext;
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public string Get(int id)
        {
            return "value";
        }


        public async Task<User> Post(User user)
        {

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;

        }

        public async Task<User> PostLogIn(string userName, string password)
        {
            //using (StreamReader reader = System.IO.File.OpenText(pathFile))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {
            //        User userFind = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (userFind.UserName == userName && userFind.Password == password)
            //            return userFind;
            //    }
            //}
            //return null;
            User userFind = await context.Users.FirstOrDefaultAsync(user => user.UserName == userName && user.Password == password);
            return userFind;
        }

        public async Task Put(int id, User user)
        {
            //    user.Id = id;
            //    string textToReplace = string.Empty;
            //    using (StreamReader reader = System.IO.File.OpenText(pathFile))
            //    {
            //        string currentUserInFile;
            //        while ((currentUserInFile = reader.ReadLine()) != null)
            //        {

            //            User putUser = JsonSerializer.Deserialize<User>(currentUserInFile);
            //            if (user.Id == id)
            //                textToReplace = currentUserInFile;
            //        }
            //    }

            //    if (textToReplace != string.Empty)
            //    {
            //        string text = System.IO.File.ReadAllText(pathFile);
            //        text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
            //        System.IO.File.WriteAllText(pathFile, text);
            //    }

            context.Users.Update(user);
            context.SaveChangesAsync();
            return;


        }


        public void Delete(int id)
        {
        }
    }
}



