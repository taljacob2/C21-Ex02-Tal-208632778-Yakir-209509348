namespace C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings
{
    public class PlayersWrapperSettings
    {
        public enum eWhoToPlayAgainst
        {
            Human,
            Computer
        }

        public PlayersWrapperSettings(eWhoToPlayAgainst i_WhoToPlayAgainst)
        {
            WhoToPlayAgainst = i_WhoToPlayAgainst;
        }

        public eWhoToPlayAgainst WhoToPlayAgainst { get; }
    }
}
