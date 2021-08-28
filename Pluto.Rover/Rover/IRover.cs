using Pluto.Rover.Models;

namespace Pluto.Rover.Rover
{
    public interface IRover
    {
        /// <summary>
        /// Position of the rover
        /// </summary>
        DirectionalPosition Position { get; }

        /// <summary>
        /// Moves the robot forward depending on its Direction
        /// </summary>
        void MoveForward();
        /// <summary>
        /// Moves the rover backward depending on its Direction
        /// </summary>
        void MoveBackward();
        /// <summary>
        /// Rotates the rover to the left
        /// </summary>
        void TurnLeft();
        /// <summary>
        /// Rotates the rover the right
        /// </summary>
        void TurnRight();
    }
}
