#region

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
            RequesterService = new RequesterServiceImpl(this);
            RequesterService.ConstructEngine();
            ResponderService = new ResponderServiceImpl(this);
        }

        public Database.Database Database { get; set; }

        public static IRequesterService RequesterService { get; set; }

        public static IResponderService ResponderService { get; set; }

        public void RunGame()
        {
            ResponderService.PrintBoard();
        }

        private void playTurn()
        {
            
        }
    }
}
