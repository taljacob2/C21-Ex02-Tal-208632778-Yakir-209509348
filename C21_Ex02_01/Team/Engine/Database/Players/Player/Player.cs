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


        public abstract void PlayTurn();

        /// <summary />
        /// <returns> Index byte of column chosen.</returns>
        protected abstract byte ChooseColumn();
    }
}
