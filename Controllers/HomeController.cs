using DiplomMag.Mocks;
using DiplomMag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiplomMag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //string url = "https://moscow.ilovebasket.ru/games/821312?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
            //string url = "https://moscow.ilovebasket.ru/games/821308?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
            for (int i = 0; i <= 8; i++)
            {
                string url = "https://moscow.ilovebasket.ru/games/82130" + (1 + i) + "?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
                var test = new GetData(url);
                var db = new CRUD(_context);
                test.WebSrap();
                db.AddTournament(DataCollection.DataCollect(test.Tournament, test.GameId));
                
            }
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
