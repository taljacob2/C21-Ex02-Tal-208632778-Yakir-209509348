#region

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

        public PlayersWrapperSettings PlayersWrapperSettings { get; }

        /// <summary>
        ///     Places a <see cref="Human" /> as the first player,
        ///     and <i>may</i> place a <see cref="Computer" /> as the second player.
        /// </summary>
        private IPlayer[] Players { get; } = new IPlayer[k_NumberOfPlayers];

        public IPlayer GetPlayerOne()
        {
            return Players[0];
        }

        /// <summary />
        /// <returns>Note: May return a <see cref="Computer" /></returns>
        public IPlayer GetPlayerTwo()
        {
            return Players[1];
        }
    }
}
