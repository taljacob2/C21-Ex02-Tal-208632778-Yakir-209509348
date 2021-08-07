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
                initializePlayerAsHuman(k_PlayerTwoChar, out getRefPlayerTwo());
            }
            else if (PlayersWrapperSettings.OpponentType ==
                     ePlayerType.Computer)
            {
                initializePlayerAsComputer(k_PlayerTwoChar,
                    out getRefPlayerTwo());
            }

            initializePlayerAsHuman(k_PlayerOneChar, out getRefPlayerOne());
        }

        private ref Player getRefPlayerOne()
        {
            return ref Players[0];
        }
        
        /// <summary />
        /// <returns>Note: May return a <see cref="Computer" /></returns>
        private ref Player getRefPlayerTwo()
        {
            return ref Players[1];
        }
        
        private static void initializePlayerAsHuman(char i_Char,
            out Player o_Player)
        {
            o_Player = new HumanPlayer(i_Char);
        }

        private static void initializePlayerAsComputer(char i_Char,
            out Player o_Player)
        {
            o_Player = new ComputerPlayer(i_Char);
        }
        
        public void PlayerOnePlayTurn()
        {
            getRefPlayerOne().PlayTurn();
        }

        public void PlayerTwoPlayTurn()
        {
            getRefPlayerTwo().PlayTurn();
        }
    }
}
