using Leapy.Logic.Services;
using Leapy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leapy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Authenticate(model.Email, model.Password))
                {
                    // TODO: Implement authentication logic
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password";
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if a user with the same email already exists
            var existingUser = await _userService.GetUserByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
                return View(model);
            }

            // Check if a user with the same username already exists
            existingUser = await _userService.GetUserByUsernameAsync(model.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError("Username", "A user with this username already exists.");
                return View(model);
            }

            // Check if the passwords match
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "The password confirmation does not match the password.");
                return View(model);
            }

            _userService.Register(model.Username, model.Email, model.Password);

            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public IActionResult Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _userService.Register(model.Username, model.Email, model.Password);
        //        // TODO: Implement registration confirmation logic
        //    }

        //    return View(model);
        //}
    }
}
