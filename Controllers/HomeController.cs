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

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
            
        }

        public IActionResult Index() => View(null);

        public ViewResult ViewPlayers(string url)
        {
			if (string.IsNullOrEmpty(url)) return View("Index", null);
			CRUD db = new CRUD(_context);
			
                var test = new GetData(url);
                test.WebSrap(db);
			var tourName = test.Tournament.Name;
            DataCollection.DataCollect(db,tourName, test.GameDate);
                var findTour = db.GetTournamentName(tourName);
            List<Player>? Model;
			Model = db.GetGameDate(test.GameDate, findTour).Players;
            var SortModel = from item in Model
                       orderby item.TeamId
                       select item;
			return View("Index", SortModel);
			

		}
        public IActionResult Privacy()=> View();
        public ViewResult ViewPlayer(string Name, string Surname) => View(new CRUD(_context).GetPlayer(Name, Surname));



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
