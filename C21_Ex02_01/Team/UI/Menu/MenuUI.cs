#region

using System;
using C21_Ex02_01.Team.Engine.Database;
using static C21_Ex02_01.Team.UI.InputUtil.InputUtil;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public static class MenuUI
    {
        public static void RunGame()
        {
            requestMatrix();

            // DEBUG print matrix
            Engine.Engine.Database.Board.Fill('X');
            Console.Out.WriteLine("Database.Board = {0}",
                Engine.Engine.Database.Board);
        }

        private static void requestMatrix()
        {
            const byte k_MinimumPixels = 4;
            const byte k_MaximumPixels = 8;

            Console.Out.WriteLine("Please enter a matrix size.");

            string range = $"(range: {k_MinimumPixels} to {k_MaximumPixels})";
            byte rows = Convert($"Number of Rows: {range}", k_MinimumPixels,
                k_MaximumPixels);
            byte cols = Convert(
                $"Number of Columns: {range}", k_MinimumPixels,
                k_MaximumPixels);

            // Initialize Database: Create a new readonly matrix in database:
            Engine.Engine.Database =
                new Database(new Board(rows, cols));
        }
    }
}
