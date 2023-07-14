using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Int
{
    public sealed class FromUIntTests
    {
        [Test]
        public void FromUIntCorrect1()
        {
            uint value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }

        [Test]
        public void FromUIntCorrect2()
        {
            uint value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}