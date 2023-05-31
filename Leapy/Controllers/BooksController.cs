using Leapy.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leapy.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        [Authorize]
        public IActionResult DisplayBooksGrid()
        {
            var books = _bookService.GetBooks();

            if (books == null)
            {
                return View();
            }

            return View(books);
        }
        public IActionResult Details(string upc)
        {
            var book = _bookService.GetBookByUPC(upc);


            return View(book);
        }
    }
}