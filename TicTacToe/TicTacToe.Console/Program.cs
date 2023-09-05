using TicTacToe.Presentation;
using TicTacToe.Application;
using TicTacToe.Application.Interfaces;

namespace TicTacToe.Console
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