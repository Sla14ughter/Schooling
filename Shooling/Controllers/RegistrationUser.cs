using Microsoft.AspNetCore.Mvc;
using Shooling.Models;

namespace Shooling.Controllers
{
    public class RegistrationUser : Controller
    {
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(UserInfo user)
        {
            //todo: add validation
            return View("Accept", user);
        }
    }
}
