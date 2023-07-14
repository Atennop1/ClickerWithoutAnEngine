using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Short
{
    public sealed class FromUShortTests
    {
        [Test]
        public void FromUShortCorrect1()
        {
            ushort value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }

        [Test]
        public void FromUShortCorrect2()
        {
            ushort value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}