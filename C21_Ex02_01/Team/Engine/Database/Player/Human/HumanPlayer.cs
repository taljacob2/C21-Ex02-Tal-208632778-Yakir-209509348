#region

using System;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Player.Human
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(char i_PlayerChar) : base(i_PlayerChar) {}

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
