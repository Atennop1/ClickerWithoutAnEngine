using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class NegateTests
    {
        [Test]
        public void IsNegateCorrect1()
        {
            var first = new IdleNumber(10, -2);
            var result = first.Negate();
            Assert.That(result.Number == -10 && result.Exponent == -2);
        }
        
        [Test]
        public void IsNegateCorrect2()
        {
            var value = new IdleNumber(-10, 2);
            var result = value.Negate();
            Assert.That(result.Number == 10 && result.Exponent == 2);
        }
    }
}