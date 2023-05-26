using Microsoft.AspNetCore.Mvc;
using Leapy.Logic.Services;
using Leapy.Logic.Models;
using Leapy.Models;

namespace Leapy.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly FavoriteService _favoriteService;
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly PhoneService _phoneService;

        public FavoriteController(FavoriteService favoriteService, UserService userService, BookService bookService, PhoneService phoneService)
        {
            _favoriteService = favoriteService;
            _userService = userService;
            _bookService = bookService;
            _phoneService = phoneService;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _userService.GetUserByEmailAsync(User.Identity.Name).Result;

            List<Book> favoriteBooks;
            if (user.favorite_books != null)
            {
                favoriteBooks = user.favorite_books.Select(b => new Book
                {
                    ImageUrl = b.ImageUrl,
                    Title = b.Title,
                    Price = b.Price,
                    UPC = b.UPC,
                    IsFavorite = b.IsFavorite
                }).ToList();
            }
            else
            {
                favoriteBooks = new List<Book>();
            }

            // Check if the user has any favorite phones
            List<Phone> favoritePhones;
            if (user.favorite_phones != null)
            {
                favoritePhones = user.favorite_phones.Select(p => new Phone
                {
                    ImageUrl = p.ImageUrl,
                    Title = p.Title,
                    Price = p.Price,
                    ArtNr = p.ArtNr,
                    IsFavorite = p.IsFavorite
                }).ToList();
            }
            else
            {
                favoritePhones = new List<Phone>();
            }

            // Pass the favorite books and phones to the view
            var viewModel = new FavoriteViewModel
            {
                FavoriteBooks = favoriteBooks,
                FavoritePhones = favoritePhones
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AddBookToFavorites(string UPC)
        {
            var currentUser = _userService.GetUserByEmailAsync(User.Identity.Name).Result;

            var book = _bookService.GetBookByUPC(UPC);

            _favoriteService.AddBookToFavorites(currentUser, book);

            return Json(new { success = true });
        }


        [HttpPost]
        public IActionResult AddPhoneToFavorites(int ArtNr)
        {
            var currentUser = _userService.GetUserByEmailAsync(User.Identity.Name).Result;

            var phone = _phoneService.GetPhoneByArtNr(ArtNr);

            _favoriteService.AddPhoneToFavorites(currentUser, phone);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemoveBookFromFavorites(string UPC)
        {
            var currentUser = _userService.GetUserByEmailAsync(User.Identity.Name).Result;

            var book = _bookService.GetBookByUPC(UPC);

            _favoriteService.RemoveBookFromFavorites(currentUser, book);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemovePhoneFromFavorites(int ArtNr)
        {
            var currentUser = _userService.GetUserByEmailAsync(User.Identity.Name).Result;

            var phone = _phoneService.GetPhoneByArtNr(ArtNr);

            _favoriteService.RemovePhoneFromFavorites(currentUser, phone);

            return Json(new { success = true });
        }
    }
}
