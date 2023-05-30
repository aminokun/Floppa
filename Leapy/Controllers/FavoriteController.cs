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

            var model = favoritePhones.Select(phone => new FavoriteViewModel
            {
                ArtNr = phone.ArtNr,
                ImageUrl = phone.ImageUrl,
                Title = phone.Title,
                Price = phone.Price,
                IsFavorite = phone.IsFavorite
            }).ToList();

            return View(model);
        }





        [HttpPost]
        public IActionResult AddPhoneToFavorites(int ArtNr)
        {

                var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
                var phone = _phoneService.GetPhoneByArtNr(ArtNr);

                _favoriteService.AddPhoneToFavorites(currentUser, phone);

                return RedirectToAction("DisplayPhonesGrid", "Phones");
        }



        [HttpPost]
        public IActionResult RemovePhoneFromFavorites(int ArtNr)
        {
            var currentUser = _userService.GetUserByUsernameAsync(User.Identity.Name).Result;
            var phone = _phoneService.GetPhoneByArtNr(ArtNr);

            _favoriteService.RemovePhoneFromFavorites(currentUser, phone);

            return RedirectToAction("ViewFavorites", "Favorite");
        }
    }
}
