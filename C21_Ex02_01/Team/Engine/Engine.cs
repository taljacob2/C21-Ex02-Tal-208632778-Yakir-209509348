#region

using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        public Engine()
        {
            constructEngineFromConsoleUI();
        }

        public Database.Database Database { get; set; }

        private void constructEngineFromConsoleUI()
        {
            // Choose from which platform to construct this Engine:
            ConsoleUI.Requester
                requester = new ConsoleUI.Requester(this); // UI.
            requester.RequestAndConstructEngine();
        }

        public void RunGame()
        {
            PrintEngineToConsoleUI();
        }

        public void PrintEngineToConsoleUI()
        {
            // Choose whom to respond this Engine:
            ConsoleUI.Responder
                responder = new ConsoleUI.Responder(this); // UI.
            responder.PrintBoard();
        }
    }
}
