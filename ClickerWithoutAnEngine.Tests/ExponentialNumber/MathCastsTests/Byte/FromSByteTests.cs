using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Byte
{
    public sealed class FromSByteTests
    {
        [Test]
        public void FromSByteCorrect1()
        {
            sbyte value = 10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }
        
        [Test]
        public void FromSByteCorrect2()
        {
            sbyte value = -10;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: -1, Exponent: 1 });
        }

        [Test]
        public void FromSByteCorrect3()
        {
            sbyte value = 0;
            var result = value.ToExponentialNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}