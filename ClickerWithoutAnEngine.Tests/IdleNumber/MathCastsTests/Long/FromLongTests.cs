using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber.MathCastsTests.Long
{
    public sealed class FromLongTests
    {
        [Test]
        public void FromLongCorrect1()
        {
            long value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }
        
        [Test]
        public void FromLongCorrect2()
        {
            long value = -10;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: -1, Exponent: 1 });
        }

        [Test]
        public void FromLongCorrect3()
        {
            long value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}