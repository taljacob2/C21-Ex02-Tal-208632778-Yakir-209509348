#region

using System;
using System.Text;
using C21_Ex02_01.Team.Engine.Database.Board.Matrix.Wrapper;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Board
{
    public class Board : MatrixWrapper<Coin.Coin>, IBoardActuator
    {
        private const char k_Delimiter = '|';
        private const char k_RowSeparator = '=';
        private const char k_EmptyCoin = ' ';

        public Board(byte i_Rows, byte i_Cols) : base(i_Rows, i_Cols)
        {
            FillCoins(k_EmptyCoin);
        }

        public void InsertCoin(byte i_ColumnToInsertTo, char i_CharCoin)
        {
            // Update bottommost empty element in column:
            Coin.Coin emptyElementInColumn =
                GetBottommostEmptyElementInColumn(i_ColumnToInsertTo);
            emptyElementInColumn.Char = i_CharCoin;
        }

        public void FillCoins(char i_CharToFill)
        {
            for (byte i = 0; i < Rows; i++)
            {
                for (byte j = 0; j < Cols; j++)
                {
                    Matrix[i, j] =
                        new Coin.Coin(new Coordinate.Coordinate(i, j),
                            i_CharToFill);
                }
            }
        }

        /// <summary>
        ///     Returns the bottommost `empty` Coin in the column, if exists.
        ///     (Its `Char` should be <see cref="k_EmptyCoin" />).
        ///     In case the column is full, the method will return a `nonEmpty` Coin.
        /// </summary>
        /// <param name="i_Column">The column to get its bottommost empty element.</param>
        /// <returns>The bottommost empty element in the column.</returns>
        public new Coin.Coin GetBottommostEmptyElementInColumn(byte i_Column)
        {
            Coin.Coin coinInColumn = null;

            // Scans from bottom to top.
            for (int i = Rows - 1; i >= 0; i--)
            {
                coinInColumn = Matrix[i, i_Column];
                if (coinInColumn.Char == k_EmptyCoin)
                {
                    break;
                }
            }

            return coinInColumn;
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
                rowAppender.AppendRowOfRowSeparators(stringBuilder);
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

            public void AppendRowOfRowSeparators(
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
