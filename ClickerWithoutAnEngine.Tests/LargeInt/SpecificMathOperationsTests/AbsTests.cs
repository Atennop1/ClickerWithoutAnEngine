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
            Assert.That(result.Number == 10 && result.Exponent == -2);
        }
        
        [Test]
        public void IsAbsCorrect2()
        {
            var value = new IdleNumber(-10, 2);
            var result = value.Abs();
            Assert.That(result.Number == 10 && result.Exponent == 2);
        }
    }
}