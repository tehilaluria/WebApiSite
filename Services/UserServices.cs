using Entities;
using Repositories;
namespace Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _userRepository;

        public UserServices(IUserRepository iuserRepository)
        {
            _userRepository = iuserRepository;
        }
        public async Task<User> getUserByEmailAndPassword(string Email, string password)
        {

            User user = await _userRepository.getUserByEmialAndPassword(Email, password);
            //return user . If it's not null, the function will return user, and if it is null, the function will return null...
            if (user != null)
            {
                return user;

            }
            return null;

        }
        public async Task<User> addUser(User user)
        {
            int result = check(user.Password);
            if (result < 2)

                return null;

            return await _userRepository.addUser(user);


        }
        public async Task<int> updateUser(int id, User user)
        {
            //Task<user> ...
            int result = check(user.Password);
            if (result < 2)
                return 0;

            return await _userRepository.updateUser(id, user);


        }

        public int check(string pwd)
        {


            var result = Zxcvbn.Core.EvaluatePassword(pwd);
            return result.Score;


        }
    }
}