#region

using C21_Ex02_01.Team.Engine.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Team.Engine.Service
{
    public interface IResponderService
    {
        void PrintBoard();

        void PrintWinner(Player i_WinnerPlayer);
    }
}
