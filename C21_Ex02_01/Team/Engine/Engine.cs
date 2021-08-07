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
            RequesterService = new RequesterServiceImpl(this);
            RequesterService.RequestAndConstructEngine();
            ResponderService = new ResponderServiceImpl(this);
        }

        public Database.Database Database { get; set; }

        public IRequesterService RequesterService { get; }

        public IResponderService ResponderService { get; }

        public void RunGame()
        {
            ResponderService.PrintBoard();
        }
    }
}
