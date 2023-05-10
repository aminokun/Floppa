using Leapy.Data.Repositories;
using Leapy.Data.DataModels;

namespace Leapy.Logic.Services
{
    public class UserService
    {
        private readonly UserDataAccess _userDataAccess;

        public UserService(UserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userDataAccess.GetUserByEmailAsync(email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _userDataAccess.GetUserByUsernameAsync(username);
        }

        public bool Authenticate(string email, string password)
        {
            var userTask = _userDataAccess.GetUserByEmailAsync(email);
            userTask.Wait();
            var user = userTask.Result;

            if (user == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }


        public void Register(string username, string email, string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                Email = email,
                Password = passwordHash
            };

            if (_userDataAccess.GetUserByEmailAsync(email) != null)
            {
                throw new ArgumentException("User with the same email already exists");
            }

            if (_userDataAccess.GetUserByUsernameAsync(username) != null)
            {
                throw new ArgumentException("User with the same username already exists");
            }

            _userDataAccess.AddUser(user);
        }

        //public void Register(string username, string email, string password)
        //{
        //    var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        //    var user = new User
        //    {
        //        Username = username,
        //        Email = email,
        //        Password = passwordHash
        //    };

        //    _userDataAccess.AddUser(user);
        //}
    }


}
