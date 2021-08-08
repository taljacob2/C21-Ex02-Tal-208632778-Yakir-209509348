#region

using C21_Ex02_01.Team.Engine.Database.Players.Player.ID;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Player
{
    public abstract class Player
    {
        protected Player(eID i_ID, char i_Char)
        {
            Char = i_Char;
            ID = i_ID;
        }

        public eID ID { get; } // Unique

        public char Char { get; }

        public byte ChosenColumnIndex { get; set; }

        public byte Score { get; set; } = 0;

        public abstract void PlayTurn();
    }
}
