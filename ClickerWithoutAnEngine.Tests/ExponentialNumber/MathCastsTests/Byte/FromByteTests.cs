using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Byte
{
    public sealed class FromByteTests
    {
        [Test]
        public void FromByteCorrect1()
        {
            byte value = 10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }

        [Test]
        public void FromByteCorrect2()
        {
            byte value = 0;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}