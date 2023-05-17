using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class FromFloatTests
    {
        [Test]
        public void FromFloatCorrect1()
        {
            float value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }
        
        [Test]
        public void FromFloatCorrect2()
        {
            float value = -10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == -1 && result.Exponent == 1);
        }

        [Test]
        public void FromFloatCorrect3()
        {
            float value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}