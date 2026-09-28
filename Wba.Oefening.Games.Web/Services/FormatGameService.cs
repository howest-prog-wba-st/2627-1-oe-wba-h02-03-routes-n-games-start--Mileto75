using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Web.Services.Interfaces;

namespace Wba.Oefening.Games.Web.Services
{
    public class FormatGameService : IFormatGameService
    {
        public string FormatGameInfo(Game game)
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

        public string FormatGameInfo(IEnumerable<Game> games)
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
