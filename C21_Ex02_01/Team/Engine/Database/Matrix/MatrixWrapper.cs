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

        /// <summary>
        ///     private for encapsulation and safety of Matrix.
        /// </summary>
        private T[,] Matrix { get; }

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

        /// <summary />
        /// <param name="i_Row" />
        /// <param name="i_Col" />
        /// <param name="i_ElementToSet" />
        /// <returns>true on success, false on fail.</returns>
        public bool SetElement(byte i_Row, byte i_Col, T i_ElementToSet)
        {
            if (i_Row > Rows || i_Col > Cols)
            {
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
            if (i_Row > Rows || i_Col > Cols)
            {
                return default(T);
            }

            return Matrix[i_Row, i_Col];
        }
    }
}
