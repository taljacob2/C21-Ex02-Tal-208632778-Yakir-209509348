namespace C21_Ex02_01.Team.Engine.Database.Board
{
    /// <summary>
    /// Class for board utilities
    /// </summary>
    public class BoardUtils
    {
        // Board dimensions
        public static readonly int NUM_ROWS = 6;
        public static readonly int NUM_COLS = 7;

        // Matrix for evaluating a board position
        private static int[,] evaluationBoard = new int[,]
        {
            {3, 4, 5, 7, 5, 4, 3},
            {4, 6, 8, 10, 8, 6, 4},
            {5, 8, 11, 13, 11, 8, 5},
            {5, 8, 11, 13, 11, 8, 5},
            {4, 6, 8, 10, 8, 6, 4},
            {3, 4, 5, 7, 5, 4, 3}
        };
    }
}
