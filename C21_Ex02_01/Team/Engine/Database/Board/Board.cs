#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C21_Ex02_01.Team.Engine.Database.Board.Matrix.Wrapper;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Board
{
    public class Board : MatrixWrapper<char>, IBoardActuator
    {
        private const char k_Delimiter = '|';
        private const char k_RowSeparator = '=';

        public Board(byte i_Rows, byte i_Cols) : base(i_Rows, i_Cols) {}

        public void InsertCoin(byte i_ColumnToInsertTo, char i_CharCoin)
        {
            List<object> emptyBoxedElementsInColumn =
                GetBoxedEmptyElementsInColumn
                    (i_ColumnToInsertTo);
            List<char> emptyElementsInColumn =
                emptyBoxedElementsInColumn.Select(i_Object => (char) i_Object)
                    .ToList();

            // Update last empty element in column:
            emptyElementsInColumn[emptyElementsInColumn.Count - 1] = i_CharCoin;

            // DEBUG TEST:
            Engine.ResponderService.PrintBoard();
        }

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


        private struct RowAppender
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
                    io_StringBuilder.Append(k_RowSeparator);
                    io_StringBuilder.Append(k_RowSeparator);
                    io_StringBuilder.Append(k_RowSeparator);
                    io_StringBuilder.Append(k_RowSeparator);
                }

                io_StringBuilder.Append(k_RowSeparator);
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
