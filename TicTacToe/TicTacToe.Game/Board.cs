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
            if(size <= 0)
            {
                throw new ArgumentException(nameof(Size));
            }

            Size = size;
            Grid = new char[size, size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = ' ';
                }
            }
        }

        public bool IsCellEmpty(int row, int col)
        {
            return true;
        }

        public bool MakeMove(int row, int col, char playerSymbol)
        {
            Grid[row, col] = playerSymbol;

            return true;
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
