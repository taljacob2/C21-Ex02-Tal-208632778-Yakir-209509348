namespace C21_Ex02_01.Team.Engine.Database.Board.Coin
{
    public class Coin
    {
        public Coin(Coordinate.Coordinate i_Coordinate, char i_Char)
        {
            Coordinate = i_Coordinate;
            Char = i_Char;
        }

        public Coordinate.Coordinate Coordinate { get; }

        public char Char { get; set; }

        public override string ToString()
        {
            return $"{Char}";
        }
    }
}
