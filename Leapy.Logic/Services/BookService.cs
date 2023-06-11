using Leapy.DTO.DataModels;
using Leapy.Factory;
using Leapy.Interfaces;
using Leapy.Models;

namespace Leapy.Logic.Services
{
    public class BookService
    {
        private readonly IBook _bookDataAccess;

        public BookService()
        {
            BookFactory bookFactory = new BookFactory();
            _bookDataAccess = bookFactory.UseBookDAL("Book");
        }

        public List<Book> GetBooks()
        {
            List<BookDTO> booksDTO = _bookDataAccess.GetBooks();

            var books = booksDTO.Select(bookDTO => CreateBook(bookDTO)).ToList();

            return books;
        }
        public Book GetBookByUPC(string upc)
        {
            BookDTO bookDTO = _bookDataAccess.GetBookByUPC(upc);

            return CreateBook(bookDTO);
        }
        public List<Book> GetFavoriteBooks(int userId)
        {
            var favoriteBooksDTO = _bookDataAccess.GetFavoriteBooks(userId);

            var favoriteBooks = favoriteBooksDTO.Select(bookDTO => CreateBook(bookDTO)).ToList();

            return favoriteBooks;
        }


        public Book CreateBook(BookDTO bookDTO)
        {
            return new Book
            {
                UPC = bookDTO.UPC,
                ImageUrl = bookDTO.ImageUrl,
                Title = bookDTO.Title,
                Price = bookDTO.Price,
                IsFavorite = bookDTO.IsFavorite
            };
        }
    }
}
