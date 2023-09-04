using FluentAssertions;

namespace TicTacToe.Game.Tests
{
    public class BoardTest
    {
        private readonly Board _board;

        public BoardTest()
        {
            _board = new Board(3);
        }

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
            char[,] expectedState = new char[,]
            {
                { 'X', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            // Act
            bool result = _board.MakeMove(0, 0, 'X');

            // Assert
            _board.Grid.Should().BeEquivalentTo(expectedState);
            result.Should().BeTrue();
        }

        [Fact]
        public void MakeMove_WhenInvalidMoveIsMade_ThenReturnsFalse()
        {
            // Arrange
            char[,] expectedState = new char[,]
            {
                { 'X', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            // Act
            bool moveX = _board.MakeMove(0, 0, 'X');
            bool moveO = _board.MakeMove(0, 0, 'O');

            // Assert
            _board.Grid.Should().BeEquivalentTo(expectedState);
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
            // Act
            bool result = _board.MakeMove(row, column, 'X');

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsWin_WhenThereIsARowWin_ThenReturnsTrue()
        {
            // Arrange
            _board.MakeMove(0, 0, 'X');
            _board.MakeMove(0, 1, 'X');
            _board.MakeMove(0, 2, 'X');

            // Act
            bool isWinX = _board.IsWin('X');

            // Assert
            isWinX.Should().BeTrue();
        }

        [Fact]
        public void IsWin_WhenThereIsAColumnWin_ThenReturnsTrue()
        {
            // Arrange
            _board.MakeMove(0, 1, 'O');
            _board.MakeMove(1, 1, 'O');
            _board.MakeMove(2, 1, 'O');

            // Act
            bool isWinO = _board.IsWin('O');

            // Assert
            isWinO.Should().BeTrue();
        }

        [Fact]
        public void IsWin_WhenThereIsADiagonalWin_ThenReturnsTrue()
        {
            // Arrange
            _board.MakeMove(0, 0, 'X');
            _board.MakeMove(1, 1, 'X');
            _board.MakeMove(2, 2, 'X');

            // Act
            bool isWinX = _board.IsWin('X');

            // Assert
            isWinX.Should().BeTrue();
        }

        [Fact]
        public void IsWin_WhenBoardIsEmpty_ThenReturnsFalse()
        {
            // Act
            bool isWinX = _board.IsWin('X');
            bool isWinO = _board.IsWin('O');

            // Assert
            isWinX.Should().BeFalse();
            isWinO.Should().BeFalse();
        }

        [Fact]
        public void IsWin_WhenBoardIsPartiallyFilledAndNoWin_ThenReturnsFalse()
        {
            // Arrange
            _board.MakeMove(0, 0, 'X');
            _board.MakeMove(0, 1, 'O');
            _board.MakeMove(1, 1, 'X');
            _board.MakeMove(1, 0, 'O');

            // Act
            bool isWinX = _board.IsWin('X');
            bool isWinO = _board.IsWin('O');

            // Assert
            isWinX.Should().BeFalse();
            isWinO.Should().BeFalse();
        }
    }
}
