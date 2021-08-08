#region

using System;
using C21_Ex02_01.Team.Engine.Database.Board;
using C21_Ex02_01.Team.Engine.Database.Players;
using C21_Ex02_01.Team.Engine.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class ActuatorServiceImpl : IActuatorService
    {
        private const byte k_Series = 4;

        private readonly Board r_Board = Engine.Database.Board;
        private readonly Players r_Players = Engine.Database.Players;

        /// <summary>
        ///     Checks if there is a valid Series-of-Coins in the Board.
        /// </summary>
        /// <returns>`Winner-Player` if exists. Else, returns `null`.</returns>
        public Player GetWinnerPlayer()
        {
            Player returnValue = null;
            Player currentPlayer = r_Players.GetCurrentPlayer();

            if (isVictory())
            {
                returnValue = currentPlayer;
                currentPlayer.Score++;
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

        /// <summary>
        ///     Scans the `Board` <see cref="r_Board" /> for a victory.
        ///     Means, looks up for a series of <see cref="k_Series" /> in a
        ///     row/column/diagonal.
        /// </summary>
        /// <returns>`true`, if a series was found. Else, `false`.</returns>
        private bool isVictory()
        {
            throw new NotImplementedException();
        }
    }
}
