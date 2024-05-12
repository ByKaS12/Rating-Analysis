using DiplomMag.Mocks;
using DiplomMag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiplomMag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string url = "https://moscow.ilovebasket.ru/games/821312?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
            //string url = "https://en.wikipedia.org/wiki/List_of_SpongeBob_SquarePants_episodes";
            var test = new GetData(url);
            test.WebSrap();
            return View();
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
