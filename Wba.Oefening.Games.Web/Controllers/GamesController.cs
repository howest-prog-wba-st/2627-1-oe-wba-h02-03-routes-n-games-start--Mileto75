using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        //declare a gamerepository
        private readonly GameRepository _gameRepository = new();

        public IActionResult Index()
        {
            //get the data(all the games)
            var games = _gameRepository.GetGames();
            //use Format methods
            var content = FormatGameInfo(games);
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
            var content = FormatGameInfo(game);
            //send to browser
            return Content(content, "text/html");
        }
        
        private string FormatGameInfo(Game game)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append("--------------------------");
            stringBuilder.Append("<ul>");
            stringBuilder.Append($"<li>Id : {game.Id}</li>");
            stringBuilder.Append($"<li>Title : {game.Title}</li>");
            stringBuilder.Append($"<li>Developer : {game.Developer.Name}</li>");
            stringBuilder.Append($"<li>Rating : {game.Rating ?? 0}</li>");
            stringBuilder.Append("</ul>");
            stringBuilder.Append("--------------------------</br>");
            return stringBuilder.ToString();
        }
        private string FormatGameInfo(IEnumerable<Game> games)
        {
            StringBuilder stringBuilder = new();
            foreach (var game in games)
            {
                //call the FormatGame(Game game) method
                stringBuilder.Append(FormatGameInfo(game));
            }
            return stringBuilder.ToString();
        }
    }
}
