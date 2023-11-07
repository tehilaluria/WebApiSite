using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Library214773780Context _Library214773780Context;
        public  UserRepository(Library214773780Context Library214773780Context)
        {
            _Library214773780Context = Library214773780Context;

        }
        public async Task<User> addUser(User user) {

            await _Library214773780Context.Users.AddAsync(user);
            await _Library214773780Context.SaveChangesAsync();
            return user;
        }
        public async Task<User> getUserByEmialAndPassword(string email, string password) {

            return await _Library214773780Context.Users.Where(p =>  p.UserName == email && p.Password == password).FirstOrDefaultAsync();

           
        }
        public async Task<int> updateUser(int id, User userUpdate) {
             _Library214773780Context.Users.Update(userUpdate);
            await _Library214773780Context.SaveChangesAsync();
            return 1;
        }


    }
}