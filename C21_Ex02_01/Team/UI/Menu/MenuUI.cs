#region

using System;
using C21_Ex02_01.Team.Engine.Database;
using C21_Ex02_01.Team.Engine.Database.Board;
using C21_Ex02_01.Team.Engine.Database.Player.Wrapper;
using C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings;
using static C21_Ex02_01.Team.Engine.Database.Player.Wrapper.Settings.
    PlayersWrapperSettings;
using static C21_Ex02_01.Team.UI.InputUtil.InputUtil;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public static class MenuUI
    {
        public static void RunGame()
        {
            initializeDatabase();
        }

        private static void initializeDatabase()
        {
            requestBoard(out byte rows, out byte cols);
            requestPlayers(out eOpponent opponent);

            // Initialize Database: Create a new readonly matrix in database:
            Board board = new Board(rows, cols);
            PlayersWrapper playersWrapper =
                new PlayersWrapper(new PlayersWrapperSettings(opponent));

            Engine.Engine.Database = new Database(board, playersWrapper);
        }

        private static void requestPlayers(out eOpponent o_Opponent)
        {
            const byte k_MinimumRange = 1;
            const byte k_MaximumRange = 2;
            string titleMessage =
                "Please choose an opponent." + Environment.NewLine;
            string humanMessage = $"{k_MinimumRange}. {eOpponent.Human}" +
                                  Environment.NewLine;
            string computerMessage = $"{k_MaximumRange}. {eOpponent.Computer}";
            string mainMessage = titleMessage + humanMessage + computerMessage;


            byte byteOpponent =
                Convert(mainMessage, k_MinimumRange, k_MaximumRange);
            byteOpponent -= k_MinimumRange;
            string stringOpponent = $"{(eOpponent) byteOpponent:G}";
            Enum.TryParse(stringOpponent, out o_Opponent);
        }

        private static void requestBoard(out byte o_Rows, out byte o_Cols)
        {
            const byte k_MinimumRange = 4;
            const byte k_MaximumRange = 8;

            Console.Out.WriteLine("Please enter a matrix size.");

            string range = $"(range: {k_MinimumRange} to {k_MaximumRange})";
            o_Rows = Convert($"Number of Rows: {range}", k_MinimumRange,
                k_MaximumRange);
            o_Cols = Convert(
                $"Number of Columns: {range}", k_MinimumRange,
                k_MaximumRange);
        }
    }
}
