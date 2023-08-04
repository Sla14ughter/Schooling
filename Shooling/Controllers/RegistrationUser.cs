using Microsoft.AspNetCore.Mvc;
using Shooling.Context;
using Shooling.Models;
using Shooling.Crypt;

namespace Shooling.Controllers
{
    public class RegistrationUser : Controller
    {
        PasswordHasher passwordHasher;
        public RegistrationUser()
        {
            passwordHasher = new PasswordHasher();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                using (DbShoolingActivity db = new DbShoolingActivity())
                {
                    if (user.IsAgree)
                    {
                        user.Salt = passwordHasher.NewSalt();
                        user.Password = passwordHasher.GetHash(user.EnterPassword, user.Salt);
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
            }
            else
            {
                return View(user);
            }
        }
    }
}
