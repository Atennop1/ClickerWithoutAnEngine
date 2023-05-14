using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class ShiftLeftTests
    {
        [Test]
        public void IsShiftLeftCorrect1()
        {
            var first = new IdleNumber(10, -2);
            var result = first.ShiftLeft(2);
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }
        
        [Test]
        public void IsShiftLeftCorrect2()
        {
            var value = new IdleNumber(-10, 2);
            var result = value.ShiftLeft(2);
            Assert.That(result.Number == -1 && result.Exponent == 5);
        }
    }
}