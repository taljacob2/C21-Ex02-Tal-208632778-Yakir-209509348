namespace C21_Ex02_01.Team.Engine.Database.Board
{
    public interface IBoardActuator
    {
        void ResetBoard();
        
        void InsertCoin(byte i_ColumnIndexToInsertTo, char i_CharCoin);
        
        bool IsVictory();
        
        bool IsFull();
    }
}
