namespace TicTacToe.Application.Interfaces
{
    public interface IUserInterface
    {
        public void WriteLine(string text);
        public void Write(string text);
        public void ClearOutput();
        public string GetInput();
        public void WaitForInput();
    }
}
