#region

using System;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Matrix
{
    public class MatrixWrapper
    {
        public MatrixWrapper(byte i_Rows, byte i_Cols)
        {
            Rows = i_Rows;
            Cols = i_Cols;
            Matrix = new char[i_Rows, i_Cols];
        }

        private static byte Rows { get; set; }

        private static byte Cols { get; set; }

        private char[,] Matrix { get; }

        public override string ToString()
        {
            return
                $"[Rows = {Rows}, Cols = {Cols}, matrix.Length = {Matrix.Length}]";
        }

        public void PrintMatrix()
        {
            foreach (char element in Matrix)
            {
                Console.Out.Write(element);
            }
        }
    }
}
