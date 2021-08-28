using System;
using NUnit.Framework;
using Pluto.Rover.Models;

namespace Pluto.Rover.Tests.Models
{
    public class PositionTests
    {
        [Test]
        public void Should_Throw_ArgumentException_If_X_Is_Less_Than_zero()
        {
            Assert.Throws<ArgumentException>(() => { new Position(-1, 0); });
        }

        [Test]
        public void Should_Throw_ArgumentException_If_Y_Is_Less_Than_zero()
        {
            Assert.Throws<ArgumentException>(() => new Position(0, -1));
        }

        [Test]
        public void Should_Throw_ArgumentException_If_X_And_Y_Are_Less_Than_zero()
        {
            Assert.Throws<ArgumentException>(() => new Position(-1, -1));
        }
    }
}
