using Leapy.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leapy.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
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
        public IActionResult Details(string UPC)
        {
            var book = _bookService.GetBookByUPC(UPC);


            return View(book);
        }
    }
}