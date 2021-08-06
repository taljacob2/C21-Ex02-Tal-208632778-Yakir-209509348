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
        private const char k_Delimiter = '|';
        private const string k_RowSeperator = "=";

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
            for (byte i = 0; i < Rows; i++)
            {
                appendRowOfElements(stringBuilder, i);
                appendRowOfRowSeperators(stringBuilder);
            }

            return stringBuilder.ToString();
        }

        private void appendRowOfElements(StringBuilder io_StringBuilder,
            byte io_CurrentRow)
        {
            for (int j = 0; j < Cols; j++)
            {
                io_StringBuilder.Append(k_Delimiter);
                io_StringBuilder.Append(k_Space);
                io_StringBuilder.Append(Matrix[io_CurrentRow, j]);
                io_StringBuilder.Append(k_Space);
            }

            io_StringBuilder.Append(k_Delimiter);
            io_StringBuilder.Append(Environment.NewLine);
        }

        private void appendRowOfRowSeperators(StringBuilder io_StringBuilder)
        {
            for (int j = 0; j < Cols; j++)
            {
                io_StringBuilder.Append(k_RowSeperator);
                io_StringBuilder.Append(k_RowSeperator);
                io_StringBuilder.Append(k_RowSeperator);
                io_StringBuilder.Append(k_RowSeperator);
            }

            io_StringBuilder.Append(k_RowSeperator);
            io_StringBuilder.Append(Environment.NewLine);
        }

        private void appendRowOfNumbers(StringBuilder io_StringBuilder)
        {
            for (int i = 0; i < Cols; i++)
            {
                io_StringBuilder.Append(k_Space);
                io_StringBuilder.Append(k_Space);
                io_StringBuilder.Append(i + 1);
                io_StringBuilder.Append(k_Space);
            }

            io_StringBuilder.Append(k_Space); // may be redundant
            io_StringBuilder.Append(Environment.NewLine);
        }
    }
}
