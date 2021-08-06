namespace C21_Ex02_01.Team.Engine.Database.Matrix
{
    public class MatrixWrapper
    {
        public MatrixWrapper(int i_Rows, int i_Cols)
        {
            Rows = i_Rows;
            Cols = i_Cols;
            Matrix = new char[i_Rows, i_Cols];
        }

        private static int Rows { get; set; }

        private static int Cols { get; set; }

        private char[,] Matrix { get; }

        public override string ToString()
        {
            return
                $"[Rows = {Rows}, Cols = {Cols}, matrix.Length = {Matrix.Length}]";
        }
    }
}
