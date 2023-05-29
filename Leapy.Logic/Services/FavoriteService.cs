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

        public void AddBookToFavorites(UserDTO user, BookDTO book)
        {
            user.favorite_books.Add(book);

            book.IsFavorite = true;

            _favoriteDataAccess.AddFavoriteBook(user.UserID, book.UPC);
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

        public void RemoveBookFromFavorites(UserDTO user, BookDTO book)
        {
            user.favorite_books.Remove(book);

            book.IsFavorite = false;

            _favoriteDataAccess.AddFavoriteBook(user.UserID, book.UPC);
        }

        public void RemovePhoneFromFavorites(UserDTO user, PhoneDTO phone)
        {
            user.favorite_phones.Remove(phone);

            phone.IsFavorite = false;

            _favoriteDataAccess.AddFavoritePhone(user.UserID, phone.ArtNr);
        }
    }
}
