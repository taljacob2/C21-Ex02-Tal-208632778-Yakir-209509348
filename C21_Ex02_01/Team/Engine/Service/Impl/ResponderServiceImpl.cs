#region

using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class ResponderServiceImpl : IResponderService
    {
        private readonly ConsoleUI.Responder r_Responder;

        public ResponderServiceImpl()
        {
            // UI: Choose whom to respond the Engine:
            r_Responder = new ConsoleUI.Responder();
        }

        public void PrintBoard()
        {
            r_Responder.PrintBoardWithScreenClearBeforePrint();
        }

        public void PrintWinner(Player i_WinnerPlayer)
        {
            r_Responder.PrintWinner(i_WinnerPlayer);
        }
    }
}
