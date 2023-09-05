using System;
namespace TicTacToe.Domain
{
    public class Coordinate
    {
        public int Row { get; }
        public int Column { get; }

        public Coordinate(int row, int column)
        {
            if(row < 0)
            {
                throw new InvalidMoveException();
            }

            if(column < 0)
            {
                throw new InvalidMoveException();
            }

            Row = row;
            Column = column;
        }
    }
}
