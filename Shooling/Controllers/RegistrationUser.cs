using Microsoft.AspNetCore.Mvc;
using Shooling.Context;
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
            using (DbShoolingActivity db = new DbShoolingActivity())
            {
                if(ModelState.IsValid)
                {
                    if(user != null && user.IsAgree)
                    {
                        db.UserInfo.Add(user);
                        db.SaveChanges();
                        return View("Accept", user);
                    }
                    else
                    {
                        //todo: Сделать что-нибудь с этим
                        return NotFound();
                    }
                }
                else
                {
                    return View(user);
                }
            }
        }
    }
}
