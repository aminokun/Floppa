using Leapy.Data.Repositories;
using Leapy.Data.DataModels;

namespace Leapy.Logic.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public List<Book> GetBooks()
        {
            List<Book> books = _bookRepository.GetBooks();

            return books;
        }
    }
}
