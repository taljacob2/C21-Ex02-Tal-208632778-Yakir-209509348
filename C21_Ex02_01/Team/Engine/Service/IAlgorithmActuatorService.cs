﻿#region

using C21_Ex02_01.Team.Engine.Database.Players.Player;

#endregion

namespace C21_Ex02_01.Team.Engine.Service
{
    public interface IAlgorithmActuatorService
    {
        /// <summary>
        ///     Checks if there is a valid Series-of-Coins in the Board.
        /// </summary>
        /// <returns>Winner player if exists. Else, returns null.</returns>
        Player GetWinnerPlayer();
    }
}
