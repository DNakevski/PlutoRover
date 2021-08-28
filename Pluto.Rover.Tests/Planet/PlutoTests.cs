using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pluto.Rover.Models;


namespace Pluto.Rover.Tests.Planet
{
    public class PlutoTests
    {
        [Test]
        public void Should_Throw_ArgumentException_If_Width_Is_Less_Than_1()
        {
            Assert.Throws<ArgumentException>(() => new Pluto.Rover.Planet.Pluto(0, 100, new List<Position>()));
        }

        [Test]
        public void Should_Throw_ArgumentException_If_Height_Is_Less_Than_1()
        {
            Assert.Throws<ArgumentException>(() => new Pluto.Rover.Planet.Pluto(100, 0, new List<Position>()));
        }

        [Test]
        public void Should_Throw_ArgumentException_If_Width_And_Height_Are_Less_Than_1()
        {
            Assert.Throws<ArgumentException>(() => new Pluto.Rover.Planet.Pluto(-1, 0, new List<Position>()));
        }

        [Test]
        public void Should_Throw_ArgumentNullException_If_Obstacles_Are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Pluto.Rover.Planet.Pluto(100, 100, null));
        }

        [TestCase(2, 2, ExpectedResult = true)]
        [TestCase(3, 3, ExpectedResult = false)]
        public bool Should_Detect_Whether_Obstacle(int x, int y)
        {
            var pluto = new Pluto.Rover.Planet.Pluto(100, 100, new List<Position>
            {
                new Position(2, 2)
            });

            return pluto.ContainsObstacleAtPosition(new Position(x, y));

        }
    }
}
