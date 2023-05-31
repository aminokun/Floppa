using Leapy.DTO.DataModels;

namespace Leapy.Interfaces
{
    public interface IFavorite
    {
        void AddFavoritePhone(UserDTO user, PhoneDTO phone);
        void RemoveFavoritePhone(UserDTO user, PhoneDTO phone);
    }
}
