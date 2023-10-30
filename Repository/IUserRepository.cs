using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> addUser(User user);
        Task<User> getUserByEmialAndPassword(string email, string password);
        Task<int> updateUser(int id, User userUpdate);
    }
}