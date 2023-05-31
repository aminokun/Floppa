using Leapy.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leapy.Controllers
{
    public class PhonesController : Controller
    {
        private readonly PhoneService _phoneService;

        public PhonesController(PhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        [Authorize]
        public IActionResult DisplayPhonesGrid()
        {
            var phones = _phoneService.GetPhones();

            if (phones == null)
            {
                return View();
            }

            return View(phones);
        }
        public IActionResult Details(int ArtNr)
        {
            var phone = _phoneService.GetPhoneByArtNr(ArtNr);


            return View(phone);
        }

    }
}