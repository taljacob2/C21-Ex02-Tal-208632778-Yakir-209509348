#region

using System;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Player.Computer
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(char i_PlayerChar) : base(i_PlayerChar) {}

        public override void PlayTurn()
        {
            throw new NotImplementedException();
        }

        public override byte ChooseColumn()
        {
            throw new NotImplementedException();
        }
    }
}
