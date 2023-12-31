using TicTacToe.Domain.BoardEntities;
using TicTacToe.Domain.GameEntities;

namespace TicTacToe.Tests.GameEntities
{
    public class GameTest
    {
        private readonly Game _game;
        private readonly Player _player1;
        private readonly Player _player2;

        public GameTest()
        {
            _player1 = new Player('X');
            _player2 = new Player('O');
            _game = new Game(_player1, _player2, 3);
        }

        [Fact]
        public void Constructor_WhenPlayersHaveTheSameSymbol_ThenThrowsException()
        {
            // Act
            Action createGame = () => new Game(new Player('X'), new Player('X'), 3);

            // Assert
            createGame.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void MakeMove_MoveIsValid_ThenReturnsTrue()
        {
            // Act
            _game.MakeMove(new Coordinate(0, 0));

            // Assert
            _game.CurrentPlayer.Should().Be(_player2);
        }

        [Fact]
        public void MakeMove_WhenMoveIsValid_ThenTogglesCurrentPlayer()
        {
            // Act
            _game.MakeMove(new Coordinate(0, 0));

            // Assert
            _game.CurrentPlayer.Should().Be(_player2);
        }

        [Fact]
        public void MakeMove_WhenMoveIsInvalid_ThenReturnsFalse()
        {
            // Arrange
            _game.MakeMove(new Coordinate(0, 0));

            // Act
            Action makeInvalidMove = () => _game.MakeMove(new Coordinate(0, 0));

            // Assert
            makeInvalidMove.Should().Throw<InvalidMoveException>();
        }

        [Fact]
        public void MakeMove_WhenMoveIsValidAndBoardIsFullAndNoWin_ThenUpdatesIsGameOverReturnsTrue()
        {
            // Arrange
            _game.MakeMove(new Coordinate(0, 0));
            _game.MakeMove(new Coordinate(0, 1));
            _game.MakeMove(new Coordinate(0, 2));
            _game.MakeMove(new Coordinate(1, 0));
            _game.MakeMove(new Coordinate(1, 1));
            _game.MakeMove(new Coordinate(2, 0));
            _game.MakeMove(new Coordinate(1, 2));
            _game.MakeMove(new Coordinate(2, 2));

            // Act
            _game.MakeMove(new Coordinate(2, 1));

            // Assert
            _game.IsGameOver.Should().BeTrue();
            _game.Winner.Should().BeEquivalentTo(new NullPlayer());
        }

        [Fact]
        public void MakeMove_WhenMoveIsValidAndBoardIsFullAndWin_ThenUpdatesWinnerAndIsGameOverReturnsTrue()
        {
            // Arrange
            _game.MakeMove(new Coordinate(0, 0));
            _game.MakeMove(new Coordinate(1, 0));
            _game.MakeMove(new Coordinate(0, 1));
            _game.MakeMove(new Coordinate(1, 1));

            // Act
            _game.MakeMove(new Coordinate(0, 2));

            // Assert
            _game.IsGameOver.Should().BeTrue();
            _game.Winner.Should().Be(_player1);
        }
    }
}