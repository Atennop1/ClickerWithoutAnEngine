using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class AbsTests
    {
        [Test]
        public void IsAbsCorrect1()
        {
            var value = new IdleNumber(10, -2);
            var result = value.Abs();
            Assert.That(result.Number == 1 && result.Exponent == -1);
        }
        
        [Test]
        public void IsAbsCorrect2()
        {
            var value = new IdleNumber(-10, 2);
            var result = value.Abs();
            Assert.That(result.Number == 1 && result.Exponent == 3);
        }
        
        [Test]
        public void IsAbsCorrect3()
        {
            var value = new IdleNumber();
            var result = value.Abs();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}