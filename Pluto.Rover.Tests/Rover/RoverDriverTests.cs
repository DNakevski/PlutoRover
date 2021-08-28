using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pluto.Rover.Models;
using Pluto.Rover.Planet;
using Pluto.Rover.Rover;
using Pluto.Rover.Utilities;

namespace Pluto.Rover.Tests.Rover
{
    public class RoverDriverTests
    {
        private IPlanet _planet;
        private IRover _rover;
        private IDriver _roverDriver;

        [SetUp]
        public void Init()
        {
            //setup the planet
            _planet = new Pluto.Rover.Planet.Pluto(15, 15, new List<Position>()
            {
                new Position(2, 2),
                new Position(4, 4),
                new Position(2, 10)
            });

            //setup the rover
            _rover = new Pluto.Rover.Rover.Rover(
                new DirectionalPosition(0, 0, Direction.North),
                _planet);

            //setup the rover driver
            _roverDriver = new RoverDriver(_rover);
        }

        [Test]
        public void Should_Throw_ArgumentNullException_If_Instructions_Are_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _roverDriver.Drive(null));
        }

        [Test]
        public void Should_Throw_ArgumentNullException_If_Instructions_Are_Empty()
        {
            Assert.Throws<ArgumentNullException>(() => _roverDriver.Drive(""));
        }

        [Test]
        public void Should_Throw_InvalidOperationException_If_Instructions_Are_Not_Valid()
        {
            //the letter 'C' is not valid
            Assert.Throws<InvalidOperationException>(() => _roverDriver.Drive("FFCBB"));
        }

        [TestCase("FFFBB", ExpectedResult = "0,1,North")]
        [TestCase("FFBFFB", ExpectedResult = "0,2,North")]
        [TestCase("FFBBBBB", ExpectedResult = "0,13,North")] //with wrapping
        [TestCase("FFFFFFFFFFFFFFFFFF", ExpectedResult = "0,2,North")] //with wrapping
        public string Should_Move_Correctly_In_One_Direction_When_Faced_North(string instructions)
        {
            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        [TestCase("FFFBB", ExpectedResult = "1,0,East")]
        [TestCase("FFBFFB", ExpectedResult = "2,0,East")]
        [TestCase("FFBBBBB", ExpectedResult = "13,0,East")] //with wrapping
        [TestCase("FFFFFFFFFFFFFFFFFF", ExpectedResult = "2,0,East")] //with wrapping
        public string Should_Move_Correctly_In_One_Direction_When_Faced_East(string instructions)
        {
            //Setup rover driver with rover direction to East
            SetupRoverDriver(new DirectionalPosition(0, 0, Direction.East));

            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        [TestCase("FFFBB", ExpectedResult = "0,9,South")]
        [TestCase("FFBFFB", ExpectedResult = "0,8,South")]
        [TestCase("FFBBBBBBBBBB", ExpectedResult = "0,2,South")] //with wrapping
        [TestCase("FFFFFFFFFFFFF", ExpectedResult = "0,13,South")] //with wrapping
        public string Should_Move_Correctly_In_One_Direction_When_Faced_South(string instructions)
        {
            //Setup rover driver with rover direction to South and Y coordinate to 10
            SetupRoverDriver(new DirectionalPosition(0, 10, Direction.South));

            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        [TestCase("FFFBB", ExpectedResult = "9,0,West")]
        [TestCase("FFBFFB", ExpectedResult = "8,0,West")]
        [TestCase("FFBBBBBBBBBB", ExpectedResult = "2,0,West")] //with wrapping
        [TestCase("FFFFFFFFFFFFF", ExpectedResult = "13,0,West")] //with wrapping
        public string Should_Move_Correctly_In_One_Direction_When_Faced_West(string instructions)
        {
            //Setup rover driver with rover direction to West and X coordinate to 10
            SetupRoverDriver(new DirectionalPosition(10, 0, Direction.West));

            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        [TestCase("L", ExpectedResult = "0,0,West")]
        [TestCase("LL", ExpectedResult = "0,0,South")]
        [TestCase("LLL", ExpectedResult = "0,0,East")]
        [TestCase("LLLL", ExpectedResult = "0,0,North")]
        [TestCase("LLLLL", ExpectedResult = "0,0,West")]
        [TestCase("LLLLLL", ExpectedResult = "0,0,South")]
        public string Should_Rotate_Correctly_To_Left(string instructions)
        {
            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        [TestCase("R", ExpectedResult = "0,0,East")]
        [TestCase("RR", ExpectedResult = "0,0,South")]
        [TestCase("RRR", ExpectedResult = "0,0,West")]
        [TestCase("RRRR", ExpectedResult = "0,0,North")]
        [TestCase("RRRRR", ExpectedResult = "0,0,East")]
        [TestCase("RRRRRR", ExpectedResult = "0,0,South")]
        public string Should_Rotate_Correctly_To_Right(string instructions)
        {
            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        [TestCase("FRFF", ExpectedResult = "2,1,East")]
        [TestCase("FRFFFLFF", ExpectedResult = "3,3,North")]
        [TestCase("FLFFRF", ExpectedResult = "14,2,North")] //with wrapping
        [TestCase("RFFLBBB", ExpectedResult = "2,13,North")] //with wrapping
        [TestCase("LFFLFFRFF", ExpectedResult = "12,14,West")] //with double wrapping
        public string Should_Move_And_Rotate_Correctly(string instructions)
        {
            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        [TestCase("FFRFFF", ExpectedResult = "1,2,East")]
        [TestCase("RFFFFLFFFFFFFF", ExpectedResult = "4,3,North")]
        [TestCase("RFFRFFFFFFFFFFFF", ExpectedResult = "2,11,South")]//with wrapping
        public string Should_Stay_Put_If_Obstacle_Detected(string instructions)
        {
            _roverDriver.Drive(instructions);
            return _rover.Position.ToString();
        }

        /// <summary>
        /// Sets up the rover driver with specified initial position for the rover
        /// </summary>
        /// <param name="roverInitialPosition">initial position of the rover</param>
        private void SetupRoverDriver(DirectionalPosition roverInitialPosition)
        {
            _rover = new Pluto.Rover.Rover.Rover(roverInitialPosition, _planet);
            _roverDriver = new RoverDriver(_rover);
        }
    }
}
