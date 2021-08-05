#region

using System;

#endregion

namespace C21_Ex02_01.Team.UI
{
    public class MenuUI
    {
        public void Run()
        {
            requestMatrix();
        }

        private void requestMatrix()
        {
            const int k_MinimumPixels = 4;
            const int k_MaximumPixels = 8;

            Console.Out.WriteLine("Please enter a matrix size.");

            string range = "(range: " + k_MinimumPixels + " to " +
                           k_MaximumPixels + ")";
            int rows =
                InputUtils.InputUtils.Convert<int>("Number of Rows: " + range);
            int cols =
                InputUtils.InputUtils.Convert<int>(
                    "Number of Columns: " + range);

            Console.Out.WriteLine("rows = {0}", rows); // debug check
            Console.Out.WriteLine("cols = {0}", cols); // debug check
        }
    }
}
