namespace C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings
{
    public class PlayersWrapperSettings
    {
        public enum eOpponent
        {
            Human,
            Computer
        }

        public PlayersWrapperSettings(eOpponent i_Opponent)
        {
            Opponent = i_Opponent;
        }

        public eOpponent Opponent { get; }
    }
}
