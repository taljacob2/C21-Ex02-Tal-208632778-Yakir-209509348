namespace C21_Ex02_01.Team.Engine.Database.Board
{
    public interface IBoardActuator
    {
        void InsertCoin(byte i_ColumnIndexToInsertTo, char i_CharCoin);

        void FillCoins(char i_CharToFill);

        bool IsFull();
    }
}
