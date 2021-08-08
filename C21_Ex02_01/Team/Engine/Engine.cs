#region

using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.Engine.Service;
using C21_Ex02_01.Team.Engine.Service.Impl;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        public Engine()
        {
            // Caution: the order here is important:
            RequesterService = new RequesterServiceImpl();
            RequesterService.ConstructEngine();
            ResponderService = new ResponderServiceImpl();
            AlgorithmActuatorService = new AlgorithmActuatorServiceImpl();
        }

        public static Database.Database Database { get; set; }

        public static IRequesterService RequesterService { get; private set; }

        public static IResponderService ResponderService { get; private set; }

        public static IAlgorithmActuatorService AlgorithmActuatorService
        {
            get;
            private set;
        }

        public void RunGame()
        {
            playTurn();
        }

        private void playTurn()
        {
            while (true)
            {
                ResponderService.PrintBoard();
                Database.Players.PlayTurn();

                if (isContinuePlay())
                {
                    continue;
                }

                return;
            }
        }

        private static bool isContinuePlay()
        {
            // Check for algorithm WIN here:
            Player winnerPlayer =
                AlgorithmActuatorService.GetWinnerPlayer();
            if (winnerPlayer == null)
            {
                return true;
            }

            printResponseAfterWin(winnerPlayer);
            return false;
        }

        private static void printResponseAfterWin(Player i_WinnerPlayer)
        {
            ResponderService.PrintWinner(i_WinnerPlayer); // UI Response.
            ResponderService.PrintScores(Database.Players); // UI Response.
        }
    }
}
