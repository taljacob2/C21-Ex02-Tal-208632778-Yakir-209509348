#region

#endregion

namespace C21_Ex02_01.Team.Engine.Database
{
    public class Database
    {
        public Database(Board i_Board)
        {
            Board = i_Board;
        }

        public Board Board { get; }
    }
}
