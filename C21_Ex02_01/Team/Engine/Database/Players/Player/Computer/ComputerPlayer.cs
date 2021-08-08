#region

using System;
using System.Collections.Generic;
using C21_Ex02_01.Team.Engine.Database.Players.Player.ID;
using C21_Ex02_01.Team.Engine.Service;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Player.Computer
{
    public class ComputerPlayer : Player
    {
        private readonly IRequesterService r_RequesterService =
            Engine.RequesterService;

        public ComputerPlayer(eID i_ID, char i_Char) : base(i_ID, i_Char) {}

        public override void PlayTurn()
        {
            Database database = Engine.Database;
            byte numberOfColumns = database.Board.Cols;
            List<byte> listOfIndexesOfNotFullColumns =
                initializeListOfIndexesOfNotFullColumns(numberOfColumns);

            r_RequesterService.ChooseColumnAsComputerPlayer(this,
                listOfIndexesOfNotFullColumns);
            try
            {
                database.Board.InsertCoin(ChosenColumnIndex, Char);
            }
            catch (Exception)
            {
                listOfIndexesOfNotFullColumns.Remove(ChosenColumnIndex);
                r_RequesterService.ChooseColumnAsComputerPlayer(this,
                    listOfIndexesOfNotFullColumns);
            }
        }

        private static List<byte> initializeListOfIndexesOfNotFullColumns(
            byte i_NumberOfColumns)
        {
            List<byte> listOfIndexesOfNotFullColumns = new List<byte>();
            for (byte i = 0; i < i_NumberOfColumns; i++)
            {
                listOfIndexesOfNotFullColumns.Add(i);
            }

            return listOfIndexesOfNotFullColumns;
        }
    }
}
