using Leapy.Data.Repositories;
using Leapy.Data.DataModels;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Cryptography;
using BCrypt.Net;

namespace Leapy.Logic.Services
{
    public class UserService
    {
        private readonly UserDataAccess _userDataAcces;

        public UserService(UserDataAccess userDataAcces)
        {
            _userDataAcces = userDataAcces;
        }

        public async Task CreateUserAsync(string username, string password)
        {
            var user = new User { Username = username, Password = password };
            if (!string.IsNullOrEmpty(password))
            {
                user.Password = HashPassword(password);
            }
            await _userDataAcces.CreateUserAsync(user);
        }

        public async Task<bool> CreateUserAsync(User user, string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                user.Password = HashPassword(password);
            }
            return await _userDataAcces.CreateUserAsync(user);
        }


        public bool ValidateUser(string username, string password)
        {
            var user = _userDataAcces.GetUserByUsername(username);
            if (user != null && !string.IsNullOrEmpty(password))
            {
                return VerifyPassword(password, user.Password);
            }
            return false;
        }



        private string HashPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        private bool VerifyPassword(string password, string? hashedPassword)
        {
            if (hashedPassword == null)
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
