using TicTacToe.Domain.BoardEntities;

namespace TicTacToe.Tests.BoardEntities
{
    public class CoordinateTests
    {
        [Fact]
        public void Constructor_WhenValidInput_ThenInitializesPropertiesCorrectly()
        {
            // Arrange
            int validRow = 2;
            int validColumn = 1;

            // Act
            var coordinate = new Coordinate(validRow, validColumn);

            // Assert
            coordinate.Row.Should().Be(validRow);
            coordinate.Column.Should().Be(validColumn);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        public void Constructor_WhenInvalidInput_ThenThrowsInvalidMoveException(int invalidRow, int invalidColumn)
        {
            // Act and Assert
            Assert.Throws<InvalidMoveException>(() => new Coordinate(invalidRow, invalidColumn));
        }
    }
}
