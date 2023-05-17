using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class FromUShortTests
    {
        [Test]
        public void FromUShortCorrect1()
        {
            ushort value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }

        [Test]
        public void FromUShortCorrect2()
        {
            ushort value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}