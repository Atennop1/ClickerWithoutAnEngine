using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class PowTests
    {
        [Test]
        public void IsPowCorrect1()
        {
            var first = new IdleNumber(5);
            var second = 2;

            var result = first.Pow(second);
            Assert.That(result.Number == 2.5f && result.Exponent == 1);
        }
        
        [Test]
        public void IsPowCorrect2()
        {
            var first = new IdleNumber(5);
            var second = -2;

            var result = first.Pow(second);
            Assert.That(result.Number == 4f && result.Exponent == -2);
        }
    }
}