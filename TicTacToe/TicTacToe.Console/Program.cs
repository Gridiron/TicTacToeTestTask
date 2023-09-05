using TicTacToe.Presentation;
using TicTacToe.Application;
using TicTacToe.Application.Interfaces;
using TicTacToe.Domain.Constants;

namespace TicTacToe.Console
{
    internal class Program
    {
        static void Main()
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            GameManager gameManager = new GameManager(userInterface);
            gameManager.StartGame(GameConstants.STANDART_FIELD_SIZE);
        }
    }
}