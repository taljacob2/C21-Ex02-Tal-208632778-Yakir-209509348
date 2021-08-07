#region

using C21_Ex02_01.Team.Engine.Database.Players.Player.Type;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Settings
{
    public class Settings
    {
        public Settings(ePlayerType i_OpponentPlayerType)
        {
            OpponentPlayerType = i_OpponentPlayerType;
        }

        public ePlayerType OpponentPlayerType { get; }
    }
}
