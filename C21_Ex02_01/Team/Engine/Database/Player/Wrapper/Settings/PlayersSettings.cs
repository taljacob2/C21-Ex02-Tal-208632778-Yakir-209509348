#region

using C21_Ex02_01.Team.Engine.Database.Player.Type;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings
{
    public class PlayersSettings
    {
        public PlayersSettings(ePlayerType i_OpponentPlayerType)
        {
            OpponentPlayerType = i_OpponentPlayerType;
        }

        public ePlayerType OpponentPlayerType { get; }
    }
}
