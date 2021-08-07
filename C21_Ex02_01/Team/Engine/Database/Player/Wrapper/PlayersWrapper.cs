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
        }

        public ePlayerTurn CurrentPlayerTurn { get; set; }

        public PlayersWrapperSettings PlayersWrapperSettings { get; }

        /// <summary>
        ///     Places a <see cref="Human" /> as the first player,
        ///     and <i>may</i> place a <see cref="Computer" /> as the second player.
        /// </summary>
        private Player[] Players { get; } = new Player[k_NumberOfPlayers];

        private Player getPlayerOne()
        {
            return Players[0];
        }

        /// ReSharper disable once FlagArgument
        private void setPlayerOne(ePlayerType i_PlayerType, char i_Char)
        {
            if (i_PlayerType == ePlayerType.Human)
            {
                Players[0] = new HumanPlayer(i_Char);
            }
            else if (i_PlayerType == ePlayerType.Computer)
            {
                Players[0] = new ComputerPlayer(i_Char);
            }
        }

        /// <summary />
        /// <returns>Note: May return a <see cref="Computer" /></returns>
        private Player getPlayerTwo()
        {
            return Players[1];
        }

        /// <summary />
        /// <param name="i_PlayerType">Note: May be a <see cref="Computer" /></param>
        /// <param name="i_Char" />
        /// ReSharper disable once FlagArgument
        private void setPlayerTwo(ePlayerType i_PlayerType, char i_Char)
        {
            if (i_PlayerType == ePlayerType.Human)
            {
                Players[1] = new HumanPlayer(i_Char);
            }
            else if (i_PlayerType == ePlayerType.Computer)
            {
                Players[1] = new ComputerPlayer(i_Char);
            }
        }
    }
}
