using Leapy.Data.Repositories;
using Leapy.Data.DataModels;

namespace Leapy.Logic.Services
{
    public class BookService
    {
        private readonly BookDataAccess _bookDataAccess;

        public BookService()
        {
            _bookDataAccess = new BookDataAccess();
        }

        public List<BookDTO> GetBooks()
        {
            List<BookDTO> books = _bookDataAccess.GetBooks();

            return books;
        }
        public BookDTO GetBookByUPC(string upc)
        {
            return _bookDataAccess.GetBookByUPC(upc);
        }
    }
}
