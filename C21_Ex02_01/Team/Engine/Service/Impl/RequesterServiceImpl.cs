#region

using System;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Computer;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Human;
using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class RequesterServiceImpl : IRequesterService
    {
        private readonly ConsoleUI.Requester r_Requester;

        public RequesterServiceImpl()
        {
            // UI: Choose from which platform to construct the Engine:
            r_Requester = new ConsoleUI.Requester();
        }

        public void ConstructEngine()
        {
            r_Requester.RequestAndConstructEngine();
        }

        public void ChooseColumnAsHumanPlayer(HumanPlayer io_HumanPlayer)
        {
            r_Requester.RequestChosenColumnHumanPlayer(io_HumanPlayer);
        }

        public void ChooseColumnAsComputerPlayer(
            ComputerPlayer io_ComputerPlayer)
        {
            
        }
    }
}
