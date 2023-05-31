using Leapy.Interfaces;
using Leapy.DTO.DataModels;

namespace Leapy.Logic.Services
{
    public class FavoriteService
    {
        private readonly IFavorite _favoriteDataAccess;

        public FavoriteService(IFavorite favoriteDataAccess)
        {
            _favoriteDataAccess = favoriteDataAccess;
        }


        public void AddFavoritePhone(UserDTO user, PhoneDTO phone)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (phone == null)
            {
                throw new ArgumentNullException(nameof(phone));
            }

            user.favorite_phones.Add(phone);

            phone.IsFavorite = true;

            _favoriteDataAccess.AddFavoritePhone(user, phone);
        }


        public void RemoveFavoritePhone(UserDTO user, PhoneDTO phone)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (phone == null)
            {
                throw new ArgumentNullException(nameof(phone));
            }

            user.favorite_phones.Remove(phone);

            phone.IsFavorite = false;

            _favoriteDataAccess.RemoveFavoritePhone(user, phone);
        }
    }
}
