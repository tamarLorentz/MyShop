using MyShop;
using System.Runtime.InteropServices;
using System.Text.Json;
namespace Resources
{
    public class UserResources : IUserResources
    {
        string pathFile = "M:\\WebAPI\\lesson1\\MyShop\\MyShop\\db.txt";

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public string Get(int id)
        {
            return "value";
        }


        public User Post(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(pathFile).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(pathFile, userJson + Environment.NewLine);
            return user;


        }

        public User PostLogIn(string userName, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User userFind = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userFind.UserName == userName && userFind.Password == password)
                        return userFind;
                }
            }
            return null;
        }

        public void Put(int id, User user)
        {
            user.Id = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User putUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(pathFile);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText(pathFile, text);
            }

        }


        public void Delete(int id)
        {
        }
    }
}



