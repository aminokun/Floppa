using Leapy.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Leapy.Controllers
{
    public class PhonesController : Controller
    {
        private readonly PhoneService _phoneService;

        public PhonesController()
        {
            _phoneService = new PhoneService();
        }

        public IActionResult DisplayPhonesGrid()
        {
            var phones = _phoneService.GetPhones();

            if (phones == null)
            {
                return View();
            }

            return View(phones);
        }
    }
}