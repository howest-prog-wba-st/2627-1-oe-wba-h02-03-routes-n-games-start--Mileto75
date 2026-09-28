using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Models;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class HomeController : Controller
    {
        //declare a gamerepository
        private readonly GameRepository _gameRepository = new();
        
        public IActionResult Index()
        {
            var games = _gameRepository.GetGames();
            
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Title}");
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
