namespace TicTacToe.Domain.GameEntities
{
    public class Player
    {
        public char Symbol { get; }

        public Player(char symbol)
        {
            Symbol = symbol;
        }
    }
}
