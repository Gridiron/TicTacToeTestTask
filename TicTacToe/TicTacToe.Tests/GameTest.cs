using FluentAssertions;
using TicTacToe.Domain;

namespace TicTacToe.Tests
{
    public class GameTest
    {
        [Fact]
        public void Constructor_WhenPlayersHaveTheSameSymbol_ThenThrowsException()
        {
            // Act
            Action createGame = () => new Game(new Player('X'), new Player('X'), 3);

            // Assert
            createGame.Should().Throw<ArgumentException>();
        }
    }
}