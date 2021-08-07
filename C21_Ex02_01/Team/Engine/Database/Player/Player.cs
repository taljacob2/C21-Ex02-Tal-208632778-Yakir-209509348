namespace C21_Ex02_01.Team.Engine.Database.Player
{
    public abstract class Player
    {
        protected Player(char i_PlayerChar)
        {
            PlayerChar = i_PlayerChar;
        }

        public char PlayerChar { get; }

        public abstract void PlayTurn();

        /// <summary />
        /// <returns> Index byte of column chosen.</returns>
        protected abstract byte ChooseColumn();
    }
}
