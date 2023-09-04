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
                for (int column = 0; column < Size; column++)
                {
                    Grid[row, column] = ' ';
                }
            }
        }

        public bool IsCellEmpty(int row, int column)
        {
            return true;
        }

        public bool MakeMove(int row, int column, char playerSymbol)
        {
            if (row < 0 || row >= Size || column < 0 || column >= Size)
            {
                return false;
            }

            if (Grid[row, column] != ' ')
            {
                return false; 
            }

            Grid[row, column] = playerSymbol;
            return true;
        }

        public bool IsWin(char playerSymbol)
        {
            for (int i = 0; i < Size; i++)
            {
                bool rowWin = true;
                bool columnWin = true;

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
                        columnWin = false;
                    }
                }

                if (rowWin || columnWin)
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

        public bool IsFull()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append(Grid[i, j]);
                    if (j < Size - 1)
                    {
                        sb.Append(" | ");
                    }
                }

                sb.AppendLine();
                if (i < Size - 1)
                {
                    sb.Append(new string('-', Size * 4 - 1));
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}
