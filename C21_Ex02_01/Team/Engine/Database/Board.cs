#region

using System;
using System.Text;
using C21_Ex02_01.Team.Engine.Database.Matrix;

#endregion

namespace C21_Ex02_01.Team.Engine.Database
{
    public class Board : MatrixWrapper<char>
    {
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
            RowAppender rowAppender = new RowAppender(this);

            stringBuilder.Append(Environment.NewLine);
            rowAppender.AppendRowOfNumbers(stringBuilder);
            for (byte i = 0; i < Rows; i++)
            {
                rowAppender.AppendRowOfElements(stringBuilder, i);
                rowAppender.AppendRowOfRowSeperators(stringBuilder);
            }

            return stringBuilder.ToString();
        }

        private class RowAppender
        {
            private readonly Board r_Board;

            public RowAppender(Board i_Board)
            {
                r_Board = i_Board;
            }

            public void AppendRowOfElements(StringBuilder io_StringBuilder,
                byte io_CurrentRow)
            {
                for (int j = 0; j < r_Board.Cols; j++)
                {
                    io_StringBuilder.Append(k_Delimiter);
                    io_StringBuilder.Append(k_Space);
                    io_StringBuilder.Append(r_Board.Matrix[io_CurrentRow, j]);
                    io_StringBuilder.Append(k_Space);
                }

                io_StringBuilder.Append(k_Delimiter);
                io_StringBuilder.Append(Environment.NewLine);
            }

            public void AppendRowOfRowSeperators(
                StringBuilder io_StringBuilder)
            {
                for (int j = 0; j < r_Board.Cols; j++)
                {
                    io_StringBuilder.Append(k_RowSeperator);
                    io_StringBuilder.Append(k_RowSeperator);
                    io_StringBuilder.Append(k_RowSeperator);
                    io_StringBuilder.Append(k_RowSeperator);
                }

                io_StringBuilder.Append(k_RowSeperator);
                io_StringBuilder.Append(Environment.NewLine);
            }

            public void AppendRowOfNumbers(StringBuilder io_StringBuilder)
            {
                for (int i = 0; i < r_Board.Cols; i++)
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
}
