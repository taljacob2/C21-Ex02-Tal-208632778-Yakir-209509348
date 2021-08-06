﻿#region

using System;
using C21_Ex02_01.Team.Engine.Database.Matrix;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public class MenuUI
    {
        public static void Run()
        {
            requestMatrix();
        }

        private static void requestMatrix()
        {
            const int k_MinimumPixels = 4;
            const int k_MaximumPixels = 8;

            Console.Out.WriteLine("Please enter a matrix size.");

            string range = "(range: " + k_MinimumPixels + " to " +
                           k_MaximumPixels + ")";
            int rows = InputUtil.InputUtil.Convert("Number of Rows: "
                                                   + range, k_MinimumPixels,
                k_MaximumPixels);
            int cols = InputUtil.InputUtil.Convert(
                "Number of Columns: " + range, k_MinimumPixels,
                k_MaximumPixels);

            Console.Out.WriteLine("rows = {0}", rows); // debug check 
            Console.Out.WriteLine("cols = {0}", cols); // debug check

            Matrix matrix = new Matrix(rows, cols);

            // Engine.Engine.Database.Matrix = matrix;

            // Console.Out.WriteLine("Matrix = {0}", Engine.Engine.Database.Matrix);
            Console.Out.WriteLine("Matrix = {0}", matrix);
        }
    }
}
