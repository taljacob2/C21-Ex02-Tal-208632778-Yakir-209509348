#region

using C21_Ex02_01.Team.Engine.Database.Player.Computer;
using C21_Ex02_01.Team.Engine.Database.Player.Human;
using C21_Ex02_01.Team.Engine.Database.Player.Turn;
using C21_Ex02_01.Team.Engine.Database.Player.Type;
using C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Player.Wrapper
{
    public class PlayersWrapper
    {
        private const byte k_NumberOfPlayers = 2;

        public PlayersWrapper(PlayersWrapperSettings i_PlayersWrapperSettings)
        {
            PlayersWrapperSettings = i_PlayersWrapperSettings;
            initializePlayers();
        }

        public ePlayerTurn CurrentPlayerTurn { get; set; }

        public PlayersWrapperSettings PlayersWrapperSettings { get; }

        /// <summary>
        ///     Places a <see cref="Human" /> as the first player,
        ///     and <i>may</i> place a <see cref="Human" /> or a <see cref="Computer" /> as
        ///     the second player.
        /// </summary>
        private Player[] Players { get; } = new Player[k_NumberOfPlayers];

        private void initializePlayers()
        {
            const char k_PlayerOneChar = 'O'; // Set arbitrarily
            const char k_PlayerTwoChar = 'X'; // Set arbitrarily

            if (PlayersWrapperSettings.OpponentType == ePlayerType.Human)
            {
                initializePlayerTwo(ePlayerType.Human, k_PlayerTwoChar);
            }
            else if (PlayersWrapperSettings.OpponentType ==
                     ePlayerType.Computer)
            {
                initializePlayerTwo(ePlayerType.Computer, k_PlayerTwoChar);
            }

            initializePlayerOne(ePlayerType.Human, k_PlayerOneChar);
        }

        private ref Player getRefPlayerOne()
        {
            return ref Players[0];
        }

        /// ReSharper disable once FlagArgument
        private void initializePlayerOne(ePlayerType i_PlayerType, char i_Char)
        {
            if (i_PlayerType == ePlayerType.Human)
            {
                getRefPlayerOne() = new HumanPlayer(i_Char);
            }
            else if (i_PlayerType == ePlayerType.Computer)
            {
                getRefPlayerOne() = new ComputerPlayer(i_Char);
            }
        }

        /// <summary />
        /// <returns>Note: May return a <see cref="Computer" /></returns>
        private ref Player getRefPlayerTwo()
        {
            return ref Players[1];
        }

        /// <summary />
        /// <param name="i_PlayerType">Note: May be a <see cref="Computer" /></param>
        /// <param name="i_Char" />
        /// ReSharper disable once FlagArgument
        private void initializePlayerTwo(ePlayerType i_PlayerType, char i_Char)
        {
            if (i_PlayerType == ePlayerType.Human)
            {
                getRefPlayerTwo() = new HumanPlayer(i_Char);
            }
            else if (i_PlayerType == ePlayerType.Computer)
            {
                getRefPlayerTwo() = new ComputerPlayer(i_Char);
            }
        }

        // ReSharper disable once FlagArgument
        public void PlayTurn(ePlayerTurn i_PlayerTurn)
        {
            if (i_PlayerTurn == ePlayerTurn.One)
            {
                getRefPlayerOne().PlayTurn();
            }
            else if (i_PlayerTurn == ePlayerTurn.Two)
            {
                getRefPlayerTwo().PlayTurn();
            }
        }
    }
}
