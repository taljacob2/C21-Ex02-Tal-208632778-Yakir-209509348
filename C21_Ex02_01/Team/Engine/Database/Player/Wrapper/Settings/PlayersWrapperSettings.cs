namespace C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings
{
    public class PlayersWrapperSettings
    {
        public enum ePlayerType
        {
            Human,
            Computer
        }

        public PlayersWrapperSettings(ePlayerType i_PlayerType)
        {
            PlayerType = i_PlayerType;
        }

        public ePlayerType PlayerType { get; }
    }
}
