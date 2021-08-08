#region

using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.Engine.Service;
using C21_Ex02_01.Team.Engine.Service.Impl;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        static Engine()
        {
            // Caution: `ResponderService` MUST be defined HERE:
            ResponderService = new ResponderServiceImpl();
        }

        public Engine()
        {
            // Caution: the order here is important:
            RequesterService = new RequesterServiceImpl();
            RequesterService.ConstructEngine(); // UI Request.
            AlgorithmActuatorService = new AlgorithmActuatorServiceImpl();
        }

        public static Database.Database Database { get; set; }

        public static IRequesterService RequesterService { get; private set; }

        public static IResponderService ResponderService { get; }

        private static IAlgorithmActuatorService AlgorithmActuatorService
        {
            get;
            set;
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

                if (Database.Board.IsFull())
                {
                    // It is a TIE.

                    /*
                     * TODO: It is a TIE:
                     * 1. Increase `Score` of both Players
                     * 2. Respond UI here <- it is a tie.
                     */
                    break;
                }

                Database.Players.PlayTurn();

                if (isNoWinnerYet())
                {
                    continue;
                }

                return;
            }
        }

        private static bool isNoWinnerYet()
        {
            bool returnValue = false;

            // Check for algorithm WIN here:
            Player winnerPlayer =
                /*
                 * TODO: need to implement: AlgorithmActuatorService.GetWinnerPlayer().
                 * Note: you may *replace* the below:`AlgorithmActuatorService.GetWinnerPlayer();`
                 * with `null` if you want to skip the algorithm, for testing purposes.  
                 */
                AlgorithmActuatorService.GetWinnerPlayer();
                // null; // TODO: Remove this. IT'S FOR TESTING PURPOSES ONLY
                
            if (winnerPlayer == null)
            {
                returnValue = true;
            }
            else
            {
                printResponseAfterWin(winnerPlayer);
            }

            return returnValue;
        }

        private static void printResponseAfterWin(Player i_WinnerPlayer)
        {
            ResponderService.PrintWinner(i_WinnerPlayer); // UI Response.
            ResponderService.PrintScores(Database.Players); // UI Response.
        }
    }
}
