using C21_Ex02_01.Team.Engine.Database.Player.Type;

namespace C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings
{
    public class PlayersWrapperSettings
    {
        public PlayersWrapperSettings(ePlayerType i_OpponentType)
        {
            OpponentType = i_OpponentType;
        }

        public ePlayerType OpponentType { get; }
    }
}
