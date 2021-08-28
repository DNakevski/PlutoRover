using System.Collections.Generic;
using NUnit.Framework;
using Pluto.Rover.Models;
using Pluto.Rover.Utilities;

namespace Pluto.Rover.Tests.Rover
{
    public class RoverTests
    {

        [Test]
        public void TurnLeft_Should_Return_Correct_Direction()
        {
            //Arrange
            var initialPosition = new DirectionalPosition(0, 0, Direction.North);
            var pluto = new Pluto.Rover.Planet.Pluto(50, 50, new List<Position>());
            var rover = new Pluto.Rover.Rover.Rover(initialPosition, pluto);

            //Act & Assert from North to West
            rover.TurnLeft();
            Assert.IsTrue(rover.Position.Direction == Direction.West);

            //Act & Assert from West to South
            rover.TurnLeft();
            Assert.IsTrue(rover.Position.Direction == Direction.South);

            //Act & Assert from South to East
            rover.TurnLeft();
            Assert.IsTrue(rover.Position.Direction == Direction.East);

            //Act & Assert from East to North
            rover.TurnLeft();
            Assert.IsTrue(rover.Position.Direction == Direction.North);
        }

        [Test]
        public void TurnRight_Should_Return_Correct_Direction()
        {
            //Arrange
            var initialPosition = new DirectionalPosition(0, 0, Direction.North);
            var pluto = new Pluto.Rover.Planet.Pluto(50, 50, new List<Position>());
            var rover = new Pluto.Rover.Rover.Rover(initialPosition, pluto);

            //Act & Assert from North to East
            rover.TurnRight();
            Assert.IsTrue(rover.Position.Direction == Direction.East);

            //Act & Assert from East to South
            rover.TurnRight();
            Assert.IsTrue(rover.Position.Direction == Direction.South);

            //Act & Assert from South to West
            rover.TurnRight();
            Assert.IsTrue(rover.Position.Direction == Direction.West);

            //Act & Assert from West to North
            rover.TurnRight();
            Assert.IsTrue(rover.Position.Direction == Direction.North);
        }
    }
}
