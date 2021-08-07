#region

using System;
using C21_Ex02_01.Team.Engine.Database.Players.Player;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Computer;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Human;
using C21_Ex02_01.Team.Engine.Database.Players.Player.ID;
using C21_Ex02_01.Team.Engine.Database.Players.Player.Type;
using C21_Ex02_01.Team.Engine.Database.Players.Settings;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players
{
    /// <summary>
    ///     This is a wrapper class for a group of <see cref="Player" />s.
    /// </summary>
    public class Players
    {
        private const byte k_NumberOfPlayers = 2;

        private readonly PlayersGetter r_PlayersGetter =
            new PlayersGetter();

        public Players(PlayersSettings i_PlayersSettings)
        {
            PlayersSettings = i_PlayersSettings;
            initializePlayers();
        }

        // Set arbitrarily the starting player.
        public eID CurrentPlayerTurn { get; set; } = eID.One;

        public PlayersSettings PlayersSettings { get; }

        private void initializePlayers()
        {
            const char k_PlayerOneChar = 'O'; // Set arbitrarily.
            const char k_PlayerTwoChar = 'X'; // Set arbitrarily.

            switch (PlayersSettings.OpponentPlayerType)
            {
                case ePlayerType.Human:
                    r_PlayersGetter.GetRefPlayerTwo() = new HumanPlayer(
                        eID.Two,
                        k_PlayerTwoChar);
                    break;
                case ePlayerType.Computer:
                    r_PlayersGetter.GetRefPlayerTwo() =
                        new ComputerPlayer(
                            eID.Two,
                            k_PlayerTwoChar);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            r_PlayersGetter.GetRefPlayerOne() = new HumanPlayer(eID.One,
                k_PlayerOneChar);
        }

        public void PlayTurn(Player.Player i_Player)
        {
            i_Player.PlayTurn();
            switchCurrentPlayerTurn(i_Player);
        }

        private void switchCurrentPlayerTurn(
            Player.Player i_CurrentPlayingPlayer)
        {
            switch (i_CurrentPlayingPlayer.ID)
            {
                case eID.One:
                    CurrentPlayerTurn = eID.Two;
                    break;
                case eID.Two:
                    CurrentPlayerTurn = eID.One;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private class PlayersGetter
        {
            /// <summary>
            ///     Places a <see cref="HumanPlayer" /> as the first player,
            ///     and <i>may</i> place a <see cref="HumanPlayer" /> or a
            ///     <see cref="ComputerPlayer" /> as the second player.
            /// </summary>
            private Player.Player[] Players { get; } =
                new Player.Player[k_NumberOfPlayers];

            internal ref Player.Player GetRefPlayerOne()
            {
                return ref Players[(byte) eID.One];
            }

            /// <summary />
            /// <returns>Note: May return a <see cref="ComputerPlayer" /></returns>
            internal ref Player.Player GetRefPlayerTwo()
            {
                return ref Players[(byte) eID.Two];
            }
        }
    }
}
