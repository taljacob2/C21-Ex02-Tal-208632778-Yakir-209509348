namespace C21_Ex02_01.Team.Engine.Database.Board.Coin
{
    public class Coin
    {
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }

            if(ReferenceEquals(this, obj))
            {
                return true;
            }

            if(obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Coin)obj);

        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Coordinate.GetHashCode() * 397) ^ Char.GetHashCode();
            }
        }

        public bool Equals(Coin other)
        {
            return Coordinate.Equals(other.Coordinate) && Char == other.Char;
        }
        public const char k_EmptyCoin = ' ';

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

        public bool IsEmpty()
        {
            return Char == k_EmptyCoin;
        }

        public static bool operator ==(Coin i_A, Coin i_B) => i_A?.Char == i_B?.Char;
        public static bool operator !=(Coin i_A, Coin i_B) => i_A?.Char != i_B?.Char;

    }
}
