using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTest
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_WhenSpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed) {
            var det = new DemeritPointsCalculator();
            Assert.That(() => det.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(66,0)]
        [TestCase(70,1)]
        [TestCase(75,2)]
        public void CalculateDemeritPoints_WhenCall_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var det = new DemeritPointsCalculator();
            var result = det.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
