using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class FromShortTests
    {
        [Test]
        public void FromShortCorrect1()
        {
            short value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }
        
        [Test]
        public void FromShortCorrect2()
        {
            short value = -10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == -1 && result.Exponent == 1);
        }

        [Test]
        public void FromShortCorrect3()
        {
            short value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}