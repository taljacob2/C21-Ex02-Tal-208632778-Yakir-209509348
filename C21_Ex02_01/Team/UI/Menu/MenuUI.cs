#region

using System;
using C21_Ex02_01.Team.Engine.Database;
using C21_Ex02_01.Team.Engine.Database.Matrix;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public static class MenuUI
    {
        public static void Run()
        {
            requestMatrix();

            // DEBUG print matrix
            Console.Out.WriteLine("Database.MatrixWrapper = {0}",
                Engine.Engine.Database.MatrixWrapper);
            Engine.Engine.Database.MatrixWrapper.PrintMatrix();
        }

        private static void requestMatrix()
        {
            const byte k_MinimumPixels = 4;
            const byte k_MaximumPixels = 8;

            Console.Out.WriteLine("Please enter a matrix size.");

            string range = "(range: " + k_MinimumPixels + " to " +
                           k_MaximumPixels + ")";
            byte rows = InputUtil.InputUtil.Convert("Number of Rows: "
                                                    + range, k_MinimumPixels,
                k_MaximumPixels);
            byte cols = InputUtil.InputUtil.Convert(
                "Number of Columns: " + range, k_MinimumPixels,
                k_MaximumPixels);

            // Initialize Database: Create a new readonly matrix in database:
            Engine.Engine.Database =
                new Database(new MatrixWrapper(rows, cols));
        }
    }
}
