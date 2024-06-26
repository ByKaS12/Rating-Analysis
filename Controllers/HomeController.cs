﻿using DiplomMag.Mocks;
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

        public IActionResult Index() => View(null);

        public ViewResult ViewPlayers(string url)
        {
            //string url = "https://moscow.ilovebasket.ru/games/821310?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
            //string url = "https://moscow.ilovebasket.ru/games/821308?apiUrl=https://reg.infobasket.su&lang=ru#protocol";
            if (string.IsNullOrEmpty(url)) return View("Index",null);
                var test = new GetData(url);
                var db = new CRUD(_context);
                test.WebSrap();
                var findId = db.AddTournament(DataCollection.DataCollect(test.Tournament, test.GameId),test.teams);
            List<Player> Model;
            Model = findId == Guid.Empty ? db.ViewGame(test.GameId) : db.ViewGame(findId);
            var SortModel = from item in Model
                       orderby item.TeamId
                       select item;
                return View("Index", SortModel);
			

		}
        public IActionResult Privacy()=> View();
        public ViewResult ViewPlayer(Guid id) => View(_context.Players.FirstOrDefault(x=>x.Id == id));


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
