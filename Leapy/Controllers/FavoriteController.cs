using Microsoft.AspNetCore.Mvc;
using Leapy.Logic.Services;
using Leapy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Leapy.Models;

namespace Leapy.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly FavoriteService _favoriteService;
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly PhoneService _phoneService;

        public FavoriteController()
        {
            _favoriteService = new FavoriteService();
            _userService = new UserService();
            _bookService = new BookService();
            _phoneService =  new PhoneService();
        }

        [HttpGet]
        public IActionResult ViewFavorites()
        {
            var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;

            var favoriteBooks = _bookService.GetFavoriteBooks(currentUser.UserID);
            var favoritePhones = _phoneService.GetFavoritePhones(currentUser.UserID);

            var model = new FavoritesViewModel
            {
                FavoriteBooks = favoriteBooks.Select(book => new FavoriteBookViewModel
                {
                    UPC = book.UPC,
                    ImageUrl = book.ImageUrl,
                    Title = book.Title,
                    Price = book.Price,
                    IsFavorite = book.IsFavorite
                }).ToList(),

                FavoritePhones = favoritePhones.Select(phone => new FavoritePhoneViewModel
                {
                    ArtNr = phone.ArtNr,
                    ImageUrl = phone.ImageUrl,
                    Title = phone.Title,
                    Price = phone.Price,
                    IsFavorite = phone.IsFavorite
                }).ToList()
            };

            return View(model);
        }






        [HttpPost]
        public IActionResult AddFavoritePhone(int ArtNr)
        {
            var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
            var phone = _phoneService.GetPhoneByArtNr(ArtNr);

            _favoriteService.AddFavoritePhone(currentUser, phone);

            return RedirectToAction("DisplayPhonesGrid", "Phones");
        }
        [HttpPost]
        public IActionResult RemoveFavoritePhone(int ArtNr)
        {
            var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
            var phone = _phoneService.GetPhoneByArtNr(ArtNr);

            _favoriteService.RemoveFavoritePhone(currentUser, phone);

            return RedirectToAction("ViewFavorites", "Favorite");
        }




        [HttpPost]
        public IActionResult AddFavoriteBook(string UPC)
        {
            var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
            var book = _bookService.GetBookByUPC(UPC);

            _favoriteService.AddFavoriteBook(currentUser, book);

            return RedirectToAction("DisplayBooksGrid", "Books");
        }
        [HttpPost]
        public IActionResult RemoveFavoriteBook(string UPC)
        {
            var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
            var book = _bookService.GetBookByUPC(UPC);

            _favoriteService.RemoveFavoriteBook(currentUser, book);

            return RedirectToAction("ViewFavorites", "Favorite");
        }
    }
}
