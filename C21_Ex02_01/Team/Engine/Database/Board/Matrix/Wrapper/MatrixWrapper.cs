﻿#region

using System;
using System.Diagnostics;
using System.Text;

#endregion

namespace C21_Ex02_01.Team.Engine.Database.Board.Matrix.Wrapper
{
    public class MatrixWrapper<T>
    {
        protected const char k_Space = ' ';

        public MatrixWrapper(byte i_Rows, byte i_Cols)
        {
            Rows = i_Rows;
            Cols = i_Cols;
            Matrix = new T[i_Rows, i_Cols];
        }

        protected MatrixWrapper() {}

        public byte Rows { get; }

        public byte Cols { get; }

        /// <summary>
        ///     private for encapsulation and safety of Matrix.
        /// </summary>
        protected T[,] Matrix { get; }

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
                    stringBuilder.Append(k_Space);
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

        /// <summary />
        /// <param name="i_Row" />
        /// <param name="i_Col" />
        /// <param name="i_ElementToSet" />
        /// <returns>true on success, false on fail.</returns>
        public bool SetElement(byte i_Row, byte i_Col, T i_ElementToSet)
        {
            if (i_Row > Rows)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                return false;
            }

            if (i_Col > Cols)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                return false;
            }

            Matrix[i_Row, i_Col] = i_ElementToSet;
            return true;
        }

        /// <summary />
        /// <param name="i_Row" />
        /// <param name="i_Col" />
        /// <returns>default, when the request is of out of bounds.</returns>
        public T GetElement(byte i_Row, byte i_Col)
        {
            if (i_Row > Rows)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                return default(T);
            }

            if (i_Col > Cols)
            {
                printOutOfBoundsErrorMessage(i_Row, i_Col);
                return default(T);
            }

            return Matrix[i_Row, i_Col];
        }

        private void printOutOfBoundsErrorMessage(byte i_Row, byte i_Col)
        {
            // Print Message.
            Console.Error.WriteLine(
                $"Out of bounds: [{i_Row}, {i_Col}] -> Matrix is: [{Rows}, {Cols}]");

            // Print stack trace info.
            StackTrace stackTrace = new StackTrace(true);
            Console.Error.WriteLine(stackTrace);
        }


        /// <summary />
        /// <param name="i_Column">The column to get its bottommost empty element.</param>
        /// <returns>The bottommost empty element in the column.</returns>
        public T GetBottommostEmptyElementInColumn(byte i_Column)
        {
            T returnElement = default(T);

            // Scans from bottom to top.
            for (int i = Rows - 1; i >= 0; i--)
            {
                returnElement = Matrix[i, i_Column];
                if (returnElement == null)
                {
                    break;
                }
            }

            return returnElement;
        }
    }
}
