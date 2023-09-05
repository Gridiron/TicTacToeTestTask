using TicTacToe.Application.Interfaces;
using TicTacToe.Domain.BoardEntities;
using TicTacToe.Domain.Exceptions;
using TicTacToe.Domain.GameEntities;

namespace TicTacToe.Application
{
    public class GameManager
    {
        private readonly IUserInterface _userInterface;

        public GameManager(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public void StartGame(int size) 
        {
            _userInterface.WriteLine("Welcome to Tic-Tac-Toe!");

            Player player1 = new Player('X');
            Player player2 = new Player('O');

            Game game = new Game(player1, player2, size);

            while (!game.IsGameOver)
            {
                _userInterface.ClearOutput();
                _userInterface.WriteLine(game.Board.ToString());

                _userInterface.WriteLine($"Current player: {game.CurrentPlayer.Symbol}");

                _userInterface.Write($"Enter row (0-{size}): ");
                int row = int.Parse(_userInterface.GetInput());

                _userInterface.Write($"Enter column (0-{size}): ");
                int column = int.Parse(_userInterface.GetInput());

                try
                {
                    game.MakeMove(new Coordinate(row, column));
                }
                catch (InvalidMoveException ex)
                {
                    _userInterface.WriteLine($"Invalid move: {ex.Message}");
                }
            }

            _userInterface.ClearOutput();

            if (game.Winner.Symbol != ' ')
            {
                _userInterface.WriteLine($"Player {game.Winner.Symbol} wins!");
            }
            else
            {
                _userInterface.WriteLine("It's a draw!");
            }

            _userInterface.WriteLine("Game over. Press any key to exit.");
            _userInterface.WaitForInput();
        }
    }
}
