using Pluto.Rover.Models;
using Pluto.Rover.Planet;
using Pluto.Rover.Utilities;
using Pluto.Rover.Utilities.Exceptions;

namespace Pluto.Rover.Rover
{
    /// <summary>
    /// Implementation of IRover
    /// </summary>
    public class Rover : IRover
    {
        private readonly IPlanet _planet;
        private DirectionalPosition _currentPosition;

        public Rover(DirectionalPosition initialPosition, IPlanet planet)
        {
            _currentPosition = initialPosition;
            _planet = planet;
        }

        ///<inheritdoc cref="IRover.Position"/>
        public DirectionalPosition Position => _currentPosition;

        ///<inheritdoc cref="IRover.MoveForward"/>
        public void MoveForward()
        {
            var xCoordinate = Position.X;
            var yCoordinate = Position.Y;

            //determine the new positions
            switch (Position.Direction)
            {
                case Direction.North:
                    yCoordinate += 1;
                    if (yCoordinate > _planet.Height)
                        yCoordinate = 0;
                    break;
                case Direction.East:
                    xCoordinate += 1;
                    if (xCoordinate > _planet.Width)
                        xCoordinate = 0;
                    break;
                case Direction.South:
                    yCoordinate -= 1;
                    if (yCoordinate < 0)
                        yCoordinate = _planet.Height;
                    break;
                case Direction.West:
                    xCoordinate -= 1;
                    if (xCoordinate < 0)
                        xCoordinate = _planet.Width;
                    break;
            }

            //check if there is obstacle on the new position
            var newPosition = new Position(xCoordinate, yCoordinate);
            if (_planet.ContainsObstacleAtPosition(newPosition))
                throw new ObstacleDetectedException(
                    $"Obstacle detected at position {newPosition}");

            //set the new position
            _currentPosition = new DirectionalPosition(xCoordinate, yCoordinate, Position.Direction);
        }

        ///<inheritdoc cref="IRover.MoveBackward"/>
        public void MoveBackward()
        {
            var xCoordinate = Position.X;
            var yCoordinate = Position.Y;

            //determine the new positions
            switch (Position.Direction)
            {
                case Direction.North:
                    yCoordinate -= 1;
                    if (yCoordinate < 0)
                        yCoordinate = _planet.Height;
                    break;
                case Direction.East:
                    xCoordinate -= 1;
                    if (xCoordinate < 0)
                        xCoordinate = _planet.Width;
                    break;
                case Direction.South:
                    yCoordinate += 1;
                    if (yCoordinate > _planet.Height)
                        yCoordinate = 0;
                    break;
                case Direction.West:
                    xCoordinate += 1;
                    if (xCoordinate > _planet.Width)
                        xCoordinate = 0;
                    break;
            }

            //check if there is obstacle on the new position
            var newPosition = new Position(xCoordinate, yCoordinate);
            if (_planet.ContainsObstacleAtPosition(newPosition))
                throw new ObstacleDetectedException(
                    $"Obstacle detected at position {newPosition}, I am staying where I am!");

            //set the new position
            _currentPosition = new DirectionalPosition(xCoordinate, yCoordinate, Position.Direction);
        }

        ///<inheritdoc cref="IRover.TurnLeft"/>
        public void TurnLeft()
        {
            var currentDirection = (int) Position.Direction;
            var newDirection = (4 + currentDirection - 1) % 4;
            _currentPosition = new DirectionalPosition(_currentPosition.X, _currentPosition.Y, (Direction)newDirection);
        }

        ///<inheritdoc cref="IRover.TurnRight" />
        public void TurnRight()
        {
            var currentDirection = (int)Position.Direction;
            var newDirection = (currentDirection + 1) % 4;
            _currentPosition = new DirectionalPosition(_currentPosition.X, _currentPosition.Y, (Direction)newDirection);
        }
    }
}
