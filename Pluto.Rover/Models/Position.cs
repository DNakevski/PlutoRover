using System;

namespace Pluto.Rover.Models
{
    /// <summary>
    /// Model class for the position, containing the X, Y coordinates
    /// </summary>
    public class Position
    {
        /// <summary>
        /// X coordinate of the position
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y coordinate of the position
        /// </summary>
        public int Y { get; }

        public Position(int x, int y)
        {
            //validate the given coordinates
            if (x < 0 || y < 0)
                throw new ArgumentException("X and Y coordinates cannot be less then 0");

            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
