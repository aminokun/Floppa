using Leapy.Data.Repositories;
using Leapy.Data.DataModels;

namespace Leapy.Logic.Services
{
    public class FavoriteService
    {
        private readonly FavoriteDataAccess _favoriteDataAccess;

        public FavoriteService()
        {
             _favoriteDataAccess = new FavoriteDataAccess();
        }


        public void AddPhoneToFavorites(UserDTO user, PhoneDTO phone)
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

            _favoriteDataAccess.AddFavoritePhone(user.UserID, phone.ArtNr);
        }


        public void RemovePhoneFromFavorites(UserDTO user, PhoneDTO phone)
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

            _favoriteDataAccess.RemoveFavoritePhone(user.UserID, phone.ArtNr);
        }
    }
}
