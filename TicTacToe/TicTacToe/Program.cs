using TicTacToe.Domain;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            Player player1 = new Player('X');
            Player player2 = new Player('O');

            Game game = new Game(player1, player2, 3);

            while (!game.IsGameOver)
            {
                Console.Clear();
                Console.WriteLine(game.Board.ToString());

                Console.WriteLine($"Current player: {game.CurrentPlayer.Symbol}");

                Console.Write($"Enter row (0-{game.Board.Size - 1}): ");
                int row = int.Parse(Console.ReadLine());

                Console.Write($"Enter column (0-{game.Board.Size - 1}): ");
                int column = int.Parse(Console.ReadLine());

                game.MakeMove(row, column);
            }

            Console.Clear();

            if (game.Winner != null)
            {
                Console.WriteLine($"Player {game.Winner.Symbol} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Console.WriteLine("Game over. Press any key to exit.");
            Console.ReadKey();
        }
    }
}