using System;
using System.Collections.Generic;
using Pluto.Rover.Models;

namespace Pluto.Rover.Planet
{
    /// <summary>
    /// Implementation of IPlanet
    /// </summary>
    public class Pluto : IPlanet
    {
        private HashSet<string> _obstacles;


        /// <inheritdoc cref="IPlanet.Width"/>
        public int Width { get; }
        /// <inheritdoc cref="IPlanet.Height"/>
        public int Height { get; }

        public Pluto(int width, int height, IEnumerable<Position> obstacles)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Pluto cannot have width or height less than 1");

            if (obstacles == null)
                throw new ArgumentNullException($"{nameof(obstacles)} cannot be null");

            Width = width;
            Height = height;
            SetupObstacles(obstacles);
        }

        /// <inheritdoc cref="IPlanet.ContainsObstacleAtPosition(Position)"/>
        public bool ContainsObstacleAtPosition(Position position)
        {
            return _obstacles.Contains(position.ToString());
        }

        private void SetupObstacles(IEnumerable<Position> obstacles)
        {
            _obstacles = new HashSet<string>();
            foreach (var obstacle in obstacles)
            {
                _obstacles.Add(obstacle.ToString());
            }
        }
    }
}
