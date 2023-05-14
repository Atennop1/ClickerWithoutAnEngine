using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class MultiplyingTests
    {
        [Test]
        public void IsMultiplyingCorrect1()
        {
            var first = new IdleNumber(12);
            var second = new IdleNumber(10, 1);

            var result = first.Multiply(second);
            Assert.That(result.Number == 1.2f && result.Exponent == 3);
        }
        
        [Test]
        public void IsMultiplyingCorrect2()
        {
            var first = new IdleNumber(12);
            var second = -100;

            var result = first.Multiply(second);
            Assert.That(result.Number == -1.2f && result.Exponent == 3);
        }
        
        [Test]
        public void IsMultiplyingCorrect3()
        {
            var first = new IdleNumber(12);
            var second = 100f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 1.2f && result.Exponent == 3);
        }
    }
}