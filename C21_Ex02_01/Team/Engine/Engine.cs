#region

using C21_Ex02_01.Team.UI;

#endregion

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        public Engine()
        {
            MenuUI.RequestAndConstructEngineDatabase();
        }

        public static Database.Database Database { get; set; }

        public void RunGame() {}
    }
}
