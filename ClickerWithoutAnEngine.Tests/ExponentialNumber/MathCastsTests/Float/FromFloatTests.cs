using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Float
{
    public sealed class FromFloatTests
    {
        [Test]
        public void FromFloatCorrect1()
        {
            float value = 10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }
        
        [Test]
        public void FromFloatCorrect2()
        {
            float value = -10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: -1, Exponent: 1 });
        }

        [Test]
        public void FromFloatCorrect3()
        {
            float value = 0;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}