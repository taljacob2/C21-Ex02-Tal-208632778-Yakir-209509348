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
        private static Engine s_Instance;

        public Engine()
        {
            // Caution: the order here is important:
            RequesterService = new RequesterServiceImpl(this);
            RequesterService.ConstructEngine();
            ResponderService = new ResponderServiceImpl(this);
            s_Instance = this;
        }

        public Database.Database Database { get; set; }

        public IRequesterService RequesterService { get; }

        public IResponderService ResponderService { get; }

        public static Engine GetInstance()
        {
            if (s_Instance == null)
            {
                s_Instance = new Engine();
            }

            return s_Instance;
        }

        public void RunGame()
        {
            // playTurn(); // TODO: need to continue implement
        }

        private void playTurn()
        {
            ResponderService.PrintBoard();
            Database.Players.PlayTurn();

            /*
             * TODO: after playing the turn:
             * 1. Check for algorithm win here <-.
             * 2. Print Response here <-.        
             */
        }
    }
}
