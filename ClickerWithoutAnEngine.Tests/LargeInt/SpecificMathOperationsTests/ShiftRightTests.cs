using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class ShiftRightTests
    {
        [Test]
        public void IsShiftRightCorrect1()
        {
            var value = new IdleNumber(10, -2);
            var result = value.ShiftRight(2);
            Assert.That(result.Number == 1 && result.Exponent == -3);
        }
        
        [Test]
        public void IsShiftRightCorrect2()
        {
            var value = new IdleNumber(-10, 2);
            var result = value.ShiftRight(2);
            Assert.That(result.Number == -1 && result.Exponent == 1);
        }
        
        [Test]
        public void IsShiftRightCorrect3()
        {
            var value = new IdleNumber(-10, 2);
            var result = value.ShiftRight(0);
            Assert.That(result.Number == -1 && result.Exponent == 3);
        }
        
        [Test]
        public void IsShiftRightCorrect4()
        {
            var value = new IdleNumber(-10, 2);
            var result = value.ShiftRight(-2);
            Assert.That(result.Number == -1 && result.Exponent == 5);
        }
    }
}