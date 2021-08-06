#region

using System;
using System.Text;
using C21_Ex02_01.Team.Engine.Database.Matrix;

#endregion

namespace C21_Ex02_01.Team.Engine.Database
{
    public class Board : MatrixWrapper<char>
    {
        private const char k_Space = ' ';

        public Board(byte i_Rows, byte i_Cols) : base(i_Rows, i_Cols) {}

        public override string ToString()
        {
            return matrixToString();
        }

        private string matrixToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Environment.NewLine);
            appendRowOfNumbers(stringBuilder);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    stringBuilder.Append(k_Space);
                    stringBuilder.Append(Matrix[i, j]);
                    stringBuilder.Append(k_Space);
                }

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        private void appendRowOfNumbers(StringBuilder io_StringBuilder)
        {
            for (int i = 0; i < Cols; i++)
            {
                io_StringBuilder.Append(k_Space);
                io_StringBuilder.Append(i + 1);
                io_StringBuilder.Append(k_Space);
            }

            io_StringBuilder.Append(Environment.NewLine);
        }
    }
}
