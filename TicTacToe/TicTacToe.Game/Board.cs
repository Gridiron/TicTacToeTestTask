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
            if (size <= 0)
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
            if (row < 0 || row >= Size || col < 0 || col >= Size)
            {
                return false;
            }

            if (Grid[row, col] != ' ')
            {
                return false; 
            }

            Grid[row, col] = playerSymbol;
            return true;
        }

        public bool IsWin(char playerSymbol)
        {
            for (int i = 0; i < Size; i++)
            {
                bool rowWin = true;
                bool colWin = true;

                for (int j = 0; j < Size; j++)
                {
                    // Check rows
                    if (Grid[i, j] != playerSymbol)
                    {
                        rowWin = false;
                    }

                    // Check columns
                    if (Grid[j, i] != playerSymbol)
                    {
                        colWin = false;
                    }
                }

                if (rowWin || colWin)
                {
                    return true;
                }
            }

            // Check diagonals
            bool topLeftToBottomRightDiagonalWin = true;
            bool topRightToBottomLeftDiagonalWin = true;
            for (int i = 0; i < Size; i++)
            {
                // Check diagonal from top-left to bottom-right
                if (Grid[i, i] != playerSymbol)
                {
                    topLeftToBottomRightDiagonalWin = false;
                }

                // Check diagonal from top-right to bottom-left
                if (Grid[i, Size - 1 - i] != playerSymbol)
                {
                    topRightToBottomLeftDiagonalWin = false;
                }
            }

            if (topLeftToBottomRightDiagonalWin || topRightToBottomLeftDiagonalWin)
            {
                return true;
            }

            // No win condition found
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
