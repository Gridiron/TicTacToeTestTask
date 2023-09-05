using TicTacToe.Presentation;
using TicTacToe.Application;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            GameManager gameManager = new GameManager(userInterface);
            gameManager.StartGame(3);
        }
    }
}