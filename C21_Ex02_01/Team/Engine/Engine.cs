#region

using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        public Engine()
        {
            // Choose where to construct this Engine from:
            MenuUI.Requester requester = new MenuUI.Requester(this); // UI.
            requester.RequestAndConstructEngine();
        }

        public Database.Database Database { get; set; }

        public void RunGame()
        {
            MenuUI.Responder responder = new MenuUI.Responder(this); // UI.
            responder.PrintBoard();
        }
    }
}
