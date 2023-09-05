namespace TicTacToe.Domain
{
    public class Move
    {
        public Coordinate Coordinate { get; }
        public char PlayerSymbol { get; }
        public int Row => Coordinate.Row;
        public int Column => Coordinate.Column;

        public Move(Coordinate coordinate, char playerSymbol)
        {
            Coordinate = coordinate;
            PlayerSymbol = playerSymbol;
        }
    }
}
