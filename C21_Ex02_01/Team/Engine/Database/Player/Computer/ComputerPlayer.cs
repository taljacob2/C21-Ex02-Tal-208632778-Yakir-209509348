﻿#region

using System;
using C21_Ex02_01.Team.Engine.Database.Player.ID;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Player.Computer
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            throw new NotImplementedException();
        }

        protected override byte ChooseColumn()
        {
            throw new NotImplementedException();
        }
    }
}
