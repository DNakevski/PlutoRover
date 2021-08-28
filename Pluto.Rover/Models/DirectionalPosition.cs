using Pluto.Rover.Utilities;

namespace Pluto.Rover.Models
{
    /// <summary>
    /// Model class for directional position, containing the X, Y coordinates and the direction
    /// </summary>
    public class DirectionalPosition : Position
    {
        public Direction Direction { get; }

        public DirectionalPosition(int x, int y, Direction direction) : base(x, y)
        {
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{X},{Y},{Direction}";
        }
    }
}
