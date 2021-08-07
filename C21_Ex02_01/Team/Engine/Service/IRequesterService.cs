#region

using C21_Ex02_01.Team.Engine.Database.Players.Player.Computer;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Human;

#endregion

namespace C21_Ex02_01.Team.Engine.Service
{
    public interface IRequesterService
    {
        void ConstructEngine();

        void ChooseColumnAsHumanPlayer(HumanPlayer io_HumanPlayer);

        void ChooseColumnAsComputerPlayer(ComputerPlayer io_ComputerPlayer);
    }
}
