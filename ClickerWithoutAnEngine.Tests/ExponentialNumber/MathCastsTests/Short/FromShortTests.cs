using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Short
{
    public sealed class FromShortTests
    {
        [Test]
        public void FromShortCorrect1()
        {
            short value = 10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }
        
        [Test]
        public void FromShortCorrect2()
        {
            short value = -10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: -1, Exponent: 1 });
        }

        [Test]
        public void FromShortCorrect3()
        {
            short value = 0;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}