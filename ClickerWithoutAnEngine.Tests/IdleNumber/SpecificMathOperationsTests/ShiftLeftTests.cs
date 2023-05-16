using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class ShiftLeftTests
    {
        [Test]
        public void IsShiftLeftCorrect1()
        {
            var first = new Math.IdleNumber(10, -2);
            var result = first.ShiftLeft(2);
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }
        
        [Test]
        public void IsShiftLeftCorrect2()
        {
            var value = new Math.IdleNumber(-10, 2);
            var result = value.ShiftLeft(2);
            Assert.That(result.Number == -1 && result.Exponent == 5);
        }
        
        [Test]
        public void IsShiftLeftCorrect3()
        {
            var value = new Math.IdleNumber(-10, 2);
            var result = value.ShiftLeft(0);
            Assert.That(result.Number == -1 && result.Exponent == 3);
        }
        
        [Test]
        public void IsShiftLeftCorrect4()
        {
            var value = new Math.IdleNumber(-10, 2);
            var result = value.ShiftLeft(-1);
            Assert.That(result.Number == -1 && result.Exponent == 2);
        }
    }
}