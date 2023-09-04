namespace TicTacToe.Domain
{
    public class Game
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public Player CurrentPlayer { get; private set; }
        public Board Board { get; }
        public bool IsGameOver { get; private set; }
        public Player Winner { get; private set; }

        public Game(Player player1, Player player2, int boardSize)
        {
            if(player1.Symbol == player2.Symbol)
            {
                throw new ArgumentException("Players can't have the same symbol");
            }

            _player1 = player1;
            _player2 = player2;
            Board = new Board(boardSize);
            CurrentPlayer = player1;
        }

        public void MakeMove(int row, int column)
        {

        }

        private void ToggleCurrentPlayer()
        {

        }
    }
}