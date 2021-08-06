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

        public IPlayer[] Players { get; } = new IPlayer[k_NumberOfPlayers];
    }
}
