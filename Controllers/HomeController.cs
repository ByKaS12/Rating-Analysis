using DiplomMag.Mocks;
using DiplomMag.models;
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

            return View(null);

        }
        public ViewResult ViewPlayers(string url)
        {
            //string url = "https://moscow.ilovebasket.ru/games/821310?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
            //string url = "https://moscow.ilovebasket.ru/games/821308?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
            if (string.IsNullOrEmpty(url)) return View("Index",null);
                var test = new GetData(url);
                var db = new CRUD(_context);
                test.WebSrap();
                var findId = db.AddTournament(DataCollection.DataCollect(test.Tournament, test.GameId));
            List<Player> Model;
            Model = findId == Guid.Empty ? db.ViewGame(test.GameId) : db.ViewGame(findId);
			return View("Index", Model);
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
