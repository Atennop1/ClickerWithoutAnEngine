using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Double
{
    public sealed class FromDoubleTests
    {
        [Test]
        public void FromDoubleCorrect1()
        {
            double value = 10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }
        
        [Test]
        public void FromDoubleCorrect2()
        {
            double value = -10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: -1, Exponent: 1 });
        }

        [Test]
        public void FromDoubleCorrect3()
        {
            double value = 0;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}