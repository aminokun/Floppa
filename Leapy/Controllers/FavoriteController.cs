using Microsoft.AspNetCore.Mvc;
using Leapy.Logic.Services;
using Leapy.Logic.Models;
using Leapy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Leapy.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult ViewFavorites()
        {
            var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
            var favoritePhones = _phoneService.GetFavoritePhones(currentUser.UserID);

            var model = new FavoriteViewModel
            {
                FavoritePhones = favoritePhones
            };

            return View(model);
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

                var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
                var phone = _phoneService.GetPhoneByArtNr(ArtNr);

                _favoriteService.AddPhoneToFavorites(currentUser, phone);

                return RedirectToAction("Details", "Phones", new { artNr = ArtNr });
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
