using Leapy.DTO.DataModels;

namespace Leapy.Interfaces
{
    public interface IUser
    {
        UserDTO? GetById(int id);
        Task<UserDTO?> GetUserByEmailAsync(string email);
        Task<UserDTO?> GetUserByUsernameAsync(string username);
        Task AddUserAsync(UserDTO user);
    }
}
