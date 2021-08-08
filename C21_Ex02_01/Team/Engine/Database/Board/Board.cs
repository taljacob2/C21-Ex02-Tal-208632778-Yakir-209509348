#region

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using C21_Ex02_01.Team.Engine.Database.Board.Coin;
using C21_Ex02_01.Team.Engine.Database.Board.Matrix.Wrapper;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Board
{
    public class Board : MatrixWrapper<Coin.Coin>, IBoardActuator
    {
        private const char k_Delimiter = '|';
        private const char k_RowSeparator = '=';

        public Board(byte i_Rows, byte i_Cols) : base(i_Rows, i_Cols)
        {
            FillCoins(Coin.Coin.k_EmptyCoin);
        }

        /// <summary>
        ///     Inserts a Coin into a column, while checking that the column is not full.
        /// </summary>
        /// <param name="i_ColumnIndexToInsertTo">The column to insert the Coin into.</param>
        /// <param name="i_CharCoin">Char of a coin, to insert into the column.</param>
        /// <exception cref="IOException">In case the column is full.</exception>
        public void InsertCoin(byte i_ColumnIndexToInsertTo, char i_CharCoin)
        {
            // Update bottommost empty element in column:
            Coin.Coin emptyElementInColumn =
                getBottommostEmptyElementInColumn(i_ColumnIndexToInsertTo);

            if (emptyElementInColumn != null)
            {
                emptyElementInColumn.Char = i_CharCoin;
            }
            else
            {
                throw new IOException(
                    $"The column: {i_ColumnIndexToInsertTo} is full.");
            }
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

        // ReSharper disable once MethodTooLong
        public bool IsFull()
        {
            bool returnValue = true;

            // Scans from top to bottom, to increase return value speed.
            for (byte i = 0; i < Rows; i++)
            {
                for (byte j = 0; j < Cols; j++)
                {
                    Coin.Coin currentCoin = Matrix[i, j];
                    if (!currentCoin.IsEmpty())
                    {
                        continue;
                    }

                    returnValue = false;
                    break;
                }

                if (returnValue == false)
                {
                    break;
                }
            }

            return returnValue;
        }

        /// <summary>
        ///     Returns the bottommost `empty` Coin in the column, if exists.
        ///     (Its `Char` should be <see cref="Coin.k_EmptyCoin" />).
        ///     In case the column is full, the method will return `null`.
        /// </summary>
        /// <param name="i_ColumnIndex">The column to get its bottommost empty element.</param>
        /// <returns>The bottommost empty element in the column.</returns>
        private Coin.Coin getBottommostEmptyElementInColumn(
            byte i_ColumnIndex)
        {
            Coin.Coin returnValue = null;
            Coin.Coin coinInColumn = null;

            // Scans from bottom to top.
            for (int i = Rows - 1; i >= 0; i--)
            {
                coinInColumn = Matrix[i, i_ColumnIndex];
                if (coinInColumn.Char == Coin.Coin.k_EmptyCoin)
                {
                    break;
                }
            }

            Debug.Assert(coinInColumn != null,
                nameof(coinInColumn) + " != null");
            if (coinInColumn.Char == Coin.Coin.k_EmptyCoin)
            {
                returnValue = coinInColumn;
            }

            return returnValue;
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
