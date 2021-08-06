#region

using C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Player.Wrapper
{
    public class PlayersWrapper
    {
        private const byte k_NumberOfPlayers = 2;

        public PlayersWrapper(PlayersManagerSettings i_PlayersManagerSettings)
        {
            PlayersManagerSettings = i_PlayersManagerSettings;
        }

        public PlayersManagerSettings PlayersManagerSettings { get; }

        public IPlayer[] Players { get; } = new IPlayer[k_NumberOfPlayers];
    }
}
