using TicTacToe.Application.Interfaces;

namespace TicTacToe.Presentation
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void ClearOutput()
        {
            Console.Clear();
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void WaitForInput()
        {
            Console.ReadKey();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}