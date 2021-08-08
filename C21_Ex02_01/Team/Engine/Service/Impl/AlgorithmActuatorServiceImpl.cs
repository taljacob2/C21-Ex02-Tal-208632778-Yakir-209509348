#region

using System;
using C21_Ex02_01.Team.Engine.Database.Board;
using C21_Ex02_01.Team.Engine.Database.Players;
using C21_Ex02_01.Team.Engine.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Team.Engine.Service.Impl
{
    public class AlgorithmActuatorServiceImpl : IAlgorithmActuatorService
    {
        private const byte k_Series = 4;

        private readonly Board r_Board = Engine.Database.Board;
        private readonly Players r_Players = Engine.Database.Players;

        /// <summary>
        ///     Checks if there is a valid Series-of-Coins in the Board.
        ///     <remarks>
        ///         If there is a win, the method sets the winner player's `Win` field to
        ///         `true`.
        ///         <see cref="setAsWinnerAndIncreaseScoreByOne" />
        ///     </remarks>
        /// </summary>
        /// <returns>Winner player if exists. Else, returns null.</returns>
        public Player GetWinnerPlayer()
        {
            Player returnValue = null;
            Player currentPlayer = r_Players.GetCurrentPlayer();


            // if ( /* TODO: NEED TO IMPLEMENT */)
            // {
            //     returnValue = currentPlayer;
            //     setAsWinnerAndIncreaseScoreByOne(currentPlayer);
            // }

            // return returnValue;
            
            throw new NotImplementedException();
        }

        private void setAsWinnerAndIncreaseScoreByOne(Player i_WinnerPlayer)
        {
            i_WinnerPlayer.Win = true;
            i_WinnerPlayer.Score++;
        }
    }
}
