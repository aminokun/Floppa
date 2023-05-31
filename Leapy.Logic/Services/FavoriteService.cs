using Leapy.Interfaces;
using Leapy.DTO.DataModels;
using Leapy.Factory;

namespace Leapy.Logic.Services
{
    public class FavoriteService
    {
        private readonly IFavorite _favoriteDataAccess;

        public FavoriteService()
        {
            FavoriteFactory favoriteFactory = new FavoriteFactory();
            _favoriteDataAccess = favoriteFactory.UseFavoriteDAL("Favorite");
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






        public void AddFavoriteBook(UserDTO user, BookDTO book)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            user.favorite_books.Add(book);

            book.IsFavorite = true;

            _favoriteDataAccess.AddFavoriteBook(user, book);
        }
        public void RemoveFavoriteBook(UserDTO user, BookDTO book)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            user.favorite_books.Remove(book);

            book.IsFavorite = false;

            _favoriteDataAccess.RemoveFavoriteBook(user, book);
        }
    }
}
