using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (DB.Database.users != null)
                return View(DB.Database.users.Count);

            return View(0);
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