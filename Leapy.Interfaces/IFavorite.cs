using Leapy.DTO.DataModels;

namespace Leapy.Interfaces
{
    public interface IFavorite
    {
        void AddFavoritePhone(UserDTO user, PhoneDTO phone);
        void RemoveFavoritePhone(UserDTO user, PhoneDTO phone);
        void AddFavoriteBook(UserDTO user, BookDTO book);
        void RemoveFavoriteBook(UserDTO user, BookDTO book);
    }
}
