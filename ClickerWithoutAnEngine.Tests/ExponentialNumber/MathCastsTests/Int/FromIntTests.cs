using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Int
{
    public sealed class FromIntTests
    {
        [Test]
        public void FromIntCorrect1()
        {
            int value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }
        
        [Test]
        public void FromIntCorrect2()
        {
            int value = -10;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: -1, Exponent: 1 });
        }

        [Test]
        public void FromIntCorrect3()
        {
            int value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}