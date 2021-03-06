#region

using C21_Ex02_01.Team.Engine.Database.Players.Player.AI;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Player
{
    public class AIPlayer : Player
    {
        // Depth of AI calculation here (== difficulty of AI):
        private readonly MinMaxAI r_MinMaxAI = new MinMaxAI(3);

        public AIPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            Database database = Engine.Database;

            // Thread.Sleep(300); // Add delay for realism.
            database.Board.InsertCoin(GetBestMove(), Char);
        }

        public byte GetBestMove()
        {
            return r_MinMaxAI.GetBestMove(this, Engine.Database.Board);
        }
    }
}
