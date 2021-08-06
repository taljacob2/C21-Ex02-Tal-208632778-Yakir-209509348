namespace C21_Ex02_01.Team.Engine.Database.Matrix
{
    public class Matrix
    {
        public Matrix(int i_Rows, int i_Cols)
        {
            Rows = i_Rows;
            Cols = i_Cols;
        }

        private static int Rows { get; set; }

        private static int Cols { get; set; }

        public override string ToString()
        {
            return $"Rows = {Rows}, Cols = {Cols}";
        }
    }
}
