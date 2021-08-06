#region

using C21_Ex02_01.Team.Engine.Database.Matrix;

#endregion

namespace C21_Ex02_01.Team.Engine.Database
{
    public class Database
    {
        public Database(MatrixWrapper<char> i_MatrixWrapper)
        {
            MatrixWrapper = i_MatrixWrapper;
        }

        public MatrixWrapper<char> MatrixWrapper { get; }
    }
}
