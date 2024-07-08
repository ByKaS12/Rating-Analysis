using DiplomMag.Mocks;
using DiplomMag.models;
using DiplomMag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DiplomMag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationContext _context;
        public CRUD db { get; set; }
        public static Player? _player { get; set; }

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
            
            //_player = db.GetPlayer("Леонид","Королев");
        }

        public IActionResult Index() => View(null);

        public ViewResult ViewPlayers(string url)
        {
			db = new CRUD(ref _context);
			//db = new CRUD(_context);
			//string url = "https://moscow.ilovebasket.ru/games/821310?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
			//string url = "https://moscow.ilovebasket.ru/games/821308?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
			if (string.IsNullOrEmpty(url)) return View("Index",null);
                var test = new GetData(url,db);
                //var db = new CRUD(_context);
                test.WebSrap();
			//var findId = db.AddTournament(DataCollection.DataCollect(test.Tournament, test.GameId),test.teams);
			var tourName = test.Tournament.Name;
            DataCollection.DataCollect(db,tourName, test.GameDate);
                var findTour = db.GetTournamentName(tourName);
            List<Player>? Model;
			Model = db.GetGameDate(test.GameDate, findTour).Players;
            var SortModel = from item in Model
                       orderby item.TeamId
                       select item;
            _player = Model.FirstOrDefault(x=>x.Name == "Леонид" || x.Surname == "Королев");
			return View("Index", SortModel);
			

		}
        public IActionResult Privacy()=> View();
        public ViewResult ViewPlayer(string Name, string Surname)
        {               
				return View(_player);
			
				//return View(db.GetPlayer(Name, Surname));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
