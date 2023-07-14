using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTest.Models;
using DB;
namespace WebTest.Controllers
{
    public class UserAccountController : Controller
    {

        private readonly ILogger<UserAccountController> _logger;
        static User? us;
        public UserAccountController(ILogger<UserAccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult CreateUserView(User user)
        {
            
            if (ModelState.IsValid)
            {
                if (Database.UserInDB(user.Email))
                {
                    return RedirectToAction("SingInAccount", "UserAccount");
                }
                var us = new User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                };
                
                Database.users.Add(us);
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        public IActionResult SingInAccount(User user)
        {
            if (ModelState.IsValid)
            {
                foreach (User DB_user in DB.Database.users)
                {
                    if (DB_user.Email == user.Email && DB_user.Password == user.Password)
                    {
                        us = DB_user;
                        return RedirectToAction("UserDataView", "UserAccount");
                    }
                }
            }
            return View();
        }

        public IActionResult UserDataView()
        {
            return View(us);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
