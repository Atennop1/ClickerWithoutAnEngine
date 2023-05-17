using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class FromLongTests
    {
        [Test]
        public void FromLongCorrect1()
        {
            long value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }
        
        [Test]
        public void FromLongCorrect2()
        {
            long value = -10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == -1 && result.Exponent == 1);
        }

        [Test]
        public void FromLongCorrect3()
        {
            long value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}