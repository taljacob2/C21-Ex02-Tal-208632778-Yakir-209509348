#region

using System;
using C21_Ex02_01.Team.Engine.Database.Matrix;
using static C21_Ex02_01.Team.Engine.Engine;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public class MenuUI
    {
        public static void Run()
        {
            requestMatrix();
            
            // DEBUG print matrix
            Console.Out.WriteLine("Database.MatrixWrapper = {0}", Database.MatrixWrapper);
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

            // Create a matrix in database:
            Database.MatrixWrapper = new MatrixWrapper(rows, cols);
        }
    }
}
