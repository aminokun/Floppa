using Leapy.Interfaces;
using Leapy.DTO.DataModels;

namespace Leapy.Logic.Services
{
    public class BookService
    {
        private readonly IBook _bookDataAccess;

        public BookService(IBook bookDataAccess)
        {
            _bookDataAccess = bookDataAccess;
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
