namespace TicTacToe.Game
{
    public class Game
    {
        public Player CurrentPlayer { get; private set; } 
        public Board Board { get; }
        public bool IsGameOver { get; private set; }
        public Player Winner { get; private set; }

        public Game(Player player1, Player player2, int boardSize)
        {
        }

        public void MakeMove(int row, int column)
        {

        }

        private void ToggleCurrentPlayer()
        {

        }
    }
}