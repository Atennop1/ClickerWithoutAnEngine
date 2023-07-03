using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber.MathCastsTests.Long
{
    public sealed class FromULongTests
    {
        [Test]
        public void FromULongCorrect1()
        {
            ulong value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }

        [Test]
        public void FromULongCorrect2()
        {
            ulong value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}