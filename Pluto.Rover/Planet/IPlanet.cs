using Pluto.Rover.Models;

namespace Pluto.Rover.Planet
{
    public interface IPlanet
    {
        /// <summary>
        /// Width of the planet
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Height of the planet
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Method that checks whether the planet contains obstacle at given position
        /// </summary>
        /// <param name="position">position</param>
        /// <returns>true/false</returns>
        bool ContainsObstacleAtPosition(Position position);

    }
}
