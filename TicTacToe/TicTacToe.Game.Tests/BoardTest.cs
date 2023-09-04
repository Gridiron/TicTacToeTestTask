using FluentAssertions;

namespace TicTacToe.Game.Tests
{
    public class BoardTest
    {
        [Fact]
        public void Constructor_WhenValidSize_ThenInitializesGridWithSpaces()
        {
            // Arrange
            char[,] expectedState = new char[,]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            // Act
            Board board = new Board(3);


            // Assert
            board.Grid.Should().BeEquivalentTo(expectedState);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WhenInvalidSize_ThenThrowsException(int size)
        {
            // Act
            Action createBoard = () => new Board(size);

            // Assert
            createBoard.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void MakeMove_WhenValidMoveIsMade_ThenUpdatesBoardAndReturnsTrue()
        {
            // Arrange
            Board board = new Board(3);
            char[,] expectedState = new char[,]
            {
                { 'X', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            // Act
            bool result = board.MakeMove(0, 0, 'X');

            // Assert
            board.Grid.Should().BeEquivalentTo(expectedState);
            result.Should().BeTrue();
        }

        [Fact]
        public void MakeMove_WhenInvalidMoveIsMade_ThenReturnsFalse()
        {
            // Arrange
            Board board = new Board(3);
            char[,] expectedState = new char[,]
            {
                { 'X', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            // Act
            bool moveX = board.MakeMove(0, 0, 'X');
            bool moveO = board.MakeMove(0, 0, 'O');

            // Assert
            board.Grid.Should().BeEquivalentTo(expectedState);
            moveX.Should().BeTrue();
            moveO.Should().BeFalse();
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(0, 3)]
        [InlineData(3, 3)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        public void MakeMove_WhenRowOrColumnAreInvalid_ThenReturnsFalse(int row, int column)
        {
            // Arrange
            Board board = new Board(3);

            // Act
            bool result = board.MakeMove(row, column, 'X');

            // Assert
            result.Should().BeFalse();
        }
    }
}
