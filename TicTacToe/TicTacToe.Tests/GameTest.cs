using FluentAssertions;
using TicTacToe.Domain;

namespace TicTacToe.Tests
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
            _game.MakeMove(0, 0);

            // Assert
            _game.CurrentPlayer.Should().Be(_player2);
        }

        [Fact]
        public void MakeMove_WhenMoveIsValid_ThenTogglesCurrentPlayer()
        {
            // Act
            _game.MakeMove(0, 0);

            // Assert
            _game.CurrentPlayer.Should().Be(_player2);
        }

        [Fact]
        public void MakeMove_WhenMoveIsInvalid_ThenReturnsFalse()
        {
            // Arrange
            _game.MakeMove(0, 0);

            // Act
            bool moveResult = _game.MakeMove(0, 0);

            // Assert
            moveResult.Should().BeFalse();
        }

        [Fact]
        public void MakeMove_WhenMoveIsValidAndBoardIsFullAndNoWin_ThenUpdatesIsGameOverReturnsTrue()
        {
            // Arrange
            _game.MakeMove(0, 0);
            _game.MakeMove(0, 1);
            _game.MakeMove(0, 2);
            _game.MakeMove(1, 0);
            _game.MakeMove(1, 1);
            _game.MakeMove(2, 0);
            _game.MakeMove(1, 2);
            _game.MakeMove(2, 2);

            // Act
            _game.MakeMove(2, 1);

            // Assert
            _game.IsGameOver.Should().BeTrue();
            _game.Winner.Should().BeNull();
        }

        [Fact]
        public void MakeMove_WhenMoveIsValidAndBoardIsFullAndWin_ThenUpdatesWinnerAndIsGameOverReturnsTrue()
        {
            // Arrange
            _game.MakeMove(0, 0);
            _game.MakeMove(1, 0);
            _game.MakeMove(0, 1);
            _game.MakeMove(1, 1);

            // Act
            _game.MakeMove(0, 2);

            // Assert
            _game.IsGameOver.Should().BeTrue();
            _game.Winner.Should().Be(_player1);
        }
    }
}