using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Web.Services.Interfaces
{
    public interface IFormatGameService
    {
        string FormatGameInfo(Game game);
        string FormatGameInfo(IEnumerable<Game> games);
    }
}
