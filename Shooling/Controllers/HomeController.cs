using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shooling.Context;
using Shooling.Models;
using System.Diagnostics;

namespace Shooling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? id)
        {
            using (DbShoolingActivity db = new DbShoolingActivity())
            {
                if (id != null)
                {
                    SchoolingActivity activity = db.ShoolingActivity.Find(id);
                    db.ShoolingActivity.Remove(activity);
                    db.SaveChanges();
                }
                List<SchoolingActivity> list = db.ShoolingActivity.Include(s => s.User).ToList();
                return View(list);
            }
        }
        [HttpGet]
        public IActionResult ActivityForm(string? id)
        {
            using (DbShoolingActivity db = new DbShoolingActivity())
            {
                List<UserInfo> users = db.UserInfo.ToList();
                SelectList usersList = new SelectList(users, "Id", "FullName");
                SchoolingActivityViewModel viewModel = new SchoolingActivityViewModel()
                {
                    Users = usersList
                };
                if (!string.IsNullOrEmpty(id))
                {
                    viewModel.Activity = db.ShoolingActivity.Find(id);
                    viewModel.SelectedUserId = viewModel.Activity.User.Id;
                    if (viewModel.Activity != null)
                    {
                        return View(viewModel);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return View(viewModel);
                }
            }
        }
        [HttpPost]
        public IActionResult ActivityForm(SchoolingActivityViewModel viewModel)
        {
            using (DbShoolingActivity db = new DbShoolingActivity())
            {
                if (ModelState.IsValid)
                {
                    viewModel.Activity.UserId = viewModel.SelectedUserId;
                    if (string.IsNullOrEmpty(viewModel.Activity.Id))
                    {
                        db.ShoolingActivity.Add(viewModel.Activity);
                    }
                    else
                    {
                        db.ShoolingActivity.Update(viewModel.Activity);
                    }
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    List<UserInfo> users = db.UserInfo.ToList();
                    viewModel.Users = new SelectList(users, "Id", "FullName");
                    return View(viewModel);
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}