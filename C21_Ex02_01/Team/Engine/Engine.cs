using C21_Ex02_01.Team.UI;

namespace C21_Ex02_01.Team.Engine
{
    public class Engine
    {
        public static Database.Database Database { get; set; }

        public Engine()
        {
            MenuUI.RequestAndConstructDatabase();
        }

        public void RunGame()
        {
            
        }
        
    }
}
