using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStore325569796Context _BookStore325569796Context;
        public  UserRepository(BookStore325569796Context BookStore325569796Context)
        {
            _BookStore325569796Context = BookStore325569796Context;

        }

        public async Task<User> addUser(User user) {

            await _BookStore325569796Context.Users.AddAsync(user);
            await _BookStore325569796Context.SaveChangesAsync();
            return user;
        }
        public async Task<User> getUserByEmialAndPassword(string email, string password) {

            return await _BookStore325569796Context.Users.Where(p =>  p.UserName == email && p.Password == password).FirstOrDefaultAsync();

           
        }
        public async Task<User> updateUser(int id, User userUpdate) {
             _BookStore325569796Context.Users.Update(userUpdate);
            await _BookStore325569796Context.SaveChangesAsync();
            return userUpdate; 
        }


    }
}