﻿#region

using C21_Ex02_01.Team.Engine.Database.Board;
using C21_Ex02_01.Team.Engine.Database.Players;
using C21_Ex02_01.Team.Engine.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class ActuatorServiceImpl : IActuatorService
    {
        private readonly Board r_Board = Engine.Database.Board;
        private readonly Players r_Players = Engine.Database.Players;

        /// <summary>
        ///     Checks if there is a valid Series-of-Coins in the Board.
        /// </summary>
        /// <returns>`Winner-Player` if exists. Else, returns `null`.</returns>
        public Player GetWinnerPlayer()
        {
            Player returnValue = null;

            if (r_Board.IsVictory())
            {
                Player nonCurrentPlayer = r_Players.GetNotCurrentPlayer();
                returnValue = nonCurrentPlayer;
                nonCurrentPlayer.Score++;
            }

            return returnValue;
        }

        public void SetTie()
        {
            Player playerOne = r_Players.GetPlayerOne();
            Player playerTwo = r_Players.GetPlayerTwo();

            playerOne.Score++;
            playerTwo.Score++;
        }
    }
}
