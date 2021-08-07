#region

using C21_Ex02_01.Team.Engine.Database.Player.Wrapper;

#endregion

namespace C21_Ex02_01.Team.Engine.Database
{
    public class Database
    {
        public Database(Board.Board i_Board, PlayersWrapper i_PlayersWrapper)
        {
            Board = i_Board;
            PlayersWrapper = i_PlayersWrapper;
        }

        public Board.Board Board { get; }

        public PlayersWrapper PlayersWrapper { get; }
    }
}
