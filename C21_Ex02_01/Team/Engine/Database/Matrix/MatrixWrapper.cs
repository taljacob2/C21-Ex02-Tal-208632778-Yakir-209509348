#region

using System;
using System.Text;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Matrix
{
    public class MatrixWrapper<T>
    {
        public MatrixWrapper(byte i_Rows, byte i_Cols)
        {
            Rows = i_Rows;
            Cols = i_Cols;
            Matrix = new T[i_Rows, i_Cols];
        }

        public byte Rows { get; }

        public byte Cols { get; }

        public T[,] Matrix { get; }

        public override string ToString()
        {
            return matrixToString();
        }

        private string matrixToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    stringBuilder.Append(Matrix[i, j]);
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public void Fill(T i_ElementToFill)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Matrix[i, j] = i_ElementToFill;
                }
            }
        }
    }
}
