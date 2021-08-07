#region

using C21_Ex02_01.Team.Engine.Database.Players.Player.Type;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Players.Settings
{
    public class Settings
    {
        public Settings(eType i_OpponentType)
        {
            OpponentType = i_OpponentType;
        }

        public eType OpponentType { get; }
    }
}
