#region

using System;
using C21_Ex02_01.Team.Engine.Database.Players.Player.ID;
using C21_Ex02_01.Team.Engine.Service;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Player.Human
{
    public class HumanPlayer : Player
    {
        private readonly IRequesterService r_RequesterService =
            Engine.RequesterService;

        private readonly IResponderService r_ResponderService =
            Engine.ResponderService;

        public HumanPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            r_RequesterService.ChooseColumnAsHumanPlayer(this);

            Database database = Engine.Database;
            try
            {
                database.Board.InsertCoin(ChosenColumn, Char);
            }
            catch (Exception e)
            {
                r_ResponderService.PrintMessage(e.Message);
                PlayTurn();
            }
        }
    }
}
