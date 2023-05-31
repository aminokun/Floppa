using Leapy.DTO.DataModels;
using Leapy.Factory;
using Leapy.Interfaces;
using Leapy.Models;

namespace Leapy.Logic.Services
{
    public class BookService
    {
        private readonly IBook _bookDataAccess;
        private readonly IBookFactory _bookFactory;


        public BookService(IBook bookDataAccess, IBookFactory bookFactory)
        {
            _bookDataAccess = bookDataAccess;
            _bookFactory = bookFactory;
        }

        public List<Book> GetBooks()
        {
            List<BookDTO> booksDTO = _bookDataAccess.GetBooks();

            var books = booksDTO.Select(bookDTO => _bookFactory.CreateBook(bookDTO)).ToList();

            return books;
        }
        public Book GetBookByUPC(string upc)
        {
            BookDTO bookDTO = _bookDataAccess.GetBookByUPC(upc);

            return _bookFactory.CreateBook(bookDTO);
        }
        public List<Book> GetFavoriteBooks(int userId)
        {
            var favoriteBooksDTO = _bookDataAccess.GetFavoriteBooks(userId);

            var favoriteBooks = favoriteBooksDTO.Select(bookDTO => _bookFactory.CreateBook(bookDTO)).ToList();

            return favoriteBooks;
        }
    }
}
