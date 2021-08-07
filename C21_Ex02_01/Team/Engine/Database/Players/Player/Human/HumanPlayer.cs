#region

using C21_Ex02_01.Team.Engine.Database.Players.Player.ID;
using C21_Ex02_01.Team.Engine.Service;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Player.Human
{
    public class HumanPlayer : Player
    {
        private readonly IRequesterService r_RequesterService =
            Engine.RequesterService;

        public HumanPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            r_RequesterService.ChooseColumnAsHumanPlayer(this);

            Database database = Engine.GetInstance().Database;
            database.Board.InsertCoin(ChosenColumn, Char);
        }
    }
}
