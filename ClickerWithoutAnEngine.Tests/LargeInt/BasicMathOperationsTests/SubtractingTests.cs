using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class SubtractingTests
    {
        [Test]
        public void IsSubtractingCorrect1()
        {
            var first = new IdleNumber(10);
            var second = new IdleNumber(10, 1);

            var result = first.Subtract(second);
            Assert.That(result.Number == -9f && result.Exponent == 1);
        }
        
        [Test]
        public void IsSubtractingCorrect2()
        {
            var first = new IdleNumber(10);
            var second = 100;

            var result = first.Subtract(second);
            Assert.That(result.Number == -9f && result.Exponent == 1);
        }
        
        [Test]
        public void IsSubtractingCorrect3()
        {
            var first = new IdleNumber(10);
            var second = 100f;

            var result = first.Subtract(second);
            Assert.That(result.Number == -9f && result.Exponent == 1);
        }
        
        [Test]
        public void IsSubtractingCorrectSecond4()
        {
            var first = new IdleNumber(10);
            var second = new IdleNumber(10, 1);

            var result = second.Subtract(first);
            Assert.That(result.Number == 9f && result.Exponent == 1);
        }
    }
}