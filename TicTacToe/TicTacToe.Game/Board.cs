using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    public record Board
    {
        public int Size { get; }
        public char[,] Grid { get; }

        public Board(int size)
        {
        }


        public bool IsCellEmpty(int row, int col)
        {
            return true;
        }

        public void MakeMove(int row, int col, char playerSymbol)
        {
        }

        public bool IsWin(char playerSymbol)
        {
            return false;
        }

        public bool IsDraw()
        {
            return true; 
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
