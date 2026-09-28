using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        //declare a gamerepository
        private readonly GameRepository _gameRepository = new();
        //declare the service class
        private readonly FormatGameService _formatGameService = new FormatGameService();

        public IActionResult Index()
        {
            //get the data(all the games)
            var games = _gameRepository.GetGames();
            //use Format methods
            var content = _formatGameService.FormatGameInfo(games);
            //send to browser
            return Content(content,"text/html");
        }
        public IActionResult ShowGame(int id)
        {
            //get the game using FirstOrDefault with id
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check if null
            if (game == null) 
            {
                return Content("NotFound","text/html");
            }
            //format the game
            var content = _formatGameService.FormatGameInfo(game);
            //send to browser
            return Content(content, "text/html");
        }
    }
}
