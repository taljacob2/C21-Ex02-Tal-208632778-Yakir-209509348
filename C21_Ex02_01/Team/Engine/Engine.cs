#region

using C21_Ex02_01.Team.Engine.Service;
using C21_Ex02_01.Team.Engine.Service.Impl;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    /// <summary>
    ///     Singleton implemented.
    /// </summary>
    public class Engine
    {
        public Engine()
        {
            // Caution: the order here is important:
            RequesterService = new RequesterServiceImpl();
            RequesterService.ConstructEngine();
            ResponderService = new ResponderServiceImpl();
        }

        public static Database.Database Database { get; set; }

        public static IRequesterService RequesterService { get; private set; }

        public static IResponderService ResponderService { get; private set; }

        public void RunGame()
        {
            playTurn(); // TODO: need to continue implement
        }

        private void playTurn()
        {
            while (true)
            {
                ResponderService.PrintBoard();
                Database.Players.PlayTurn();
                checkIfThereIsWin();
                if (Database.Win)
                {
                    return;
                }

                /*
                 * TODO: after playing the turn:
                 * 1. Check for algorithm win here <-.
                 * 2. Print Response here <-.        
                 */
            }
        }

        private void checkIfThereIsWin()
        {
            
        }
    }
}
