using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {

        private const string filePath = "../Users.txt";
        public async Task<User> getUserByEmialAndPassword(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == email && user.Password == password)
                        return user;
                }
            }
            return null;
        }

        public async Task<User> addUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }
        public async Task<int> updateUser(int id, User userUpdate)
        {

            //userUpdate.UserId = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userUpdate));
                System.IO.File.WriteAllText(filePath, text);
                return 1;
            }
            return 0;

        }



    }
}