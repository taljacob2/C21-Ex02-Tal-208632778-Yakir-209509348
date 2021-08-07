#region

using C21_Ex02_01.Team.Engine.Service;
using C21_Ex02_01.Team.Engine.Service.Impl;
using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        public Engine()
        {
            constructEngineFromConsoleUI();
            ResponderService = new ResponderServiceImpl(this);
        }

        public Database.Database Database { get; set; }

        public IResponderService ResponderService { get; }

        private void constructEngineFromConsoleUI()
        {
            // Choose from which platform to construct this Engine:
            ConsoleUI.Requester
                requester = new ConsoleUI.Requester(this); // UI.
            requester.RequestAndConstructEngine();
        }

        public void RunGame()
        {
            ResponderService.PrintEngineToConsoleUI();
        }
    }
}
