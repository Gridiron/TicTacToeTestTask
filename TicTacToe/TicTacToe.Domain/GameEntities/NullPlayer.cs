using TicTacToe.Domain.Constants;

namespace TicTacToe.Domain.GameEntities
{
    public class NullPlayer : Player
    {
        public NullPlayer() : base(GameConstants.SPACE_SYMBOL)
        {
        }
    }
}
