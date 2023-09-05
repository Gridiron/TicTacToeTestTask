namespace TicTacToe.Domain
{
    public class Game
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public Player CurrentPlayer { get; private set; }
        public Board Board { get; }
        public bool IsGameOver { get; private set; } = false;
        public Player Winner { get; private set; } = new NullPlayer();

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

        public void MakeMove(Coordinate coordinate)
        {
            if (IsGameOver)
            {
                throw new InvalidMoveException();
            }

            Board.MakeMove(new Move(coordinate, CurrentPlayer.Symbol));
            if (Board.IsWin(CurrentPlayer.Symbol))
            {
                IsGameOver = true;
                Winner = CurrentPlayer;
            }
            else if (Board.IsFull())
            {
                IsGameOver = true;
            }
            else
            {
                ToggleCurrentPlayer();
            }
        }

        private void ToggleCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == _player1) ? _player2 : _player1;
        }
    }
}