using Entities;

namespace Services
{
    public interface IUserServices
    {
        Task<User> addUser(User user);
        int check(string pwd);
        Task<User> getUserByEmailAndPassword(string Email, string password);
        Task<User> updateUser(int id, User user);
    }
}