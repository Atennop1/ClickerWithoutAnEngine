using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class FromSByteTests
    {
        [Test]
        public void FromSByteCorrect1()
        {
            sbyte value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }
        
        [Test]
        public void FromSByteCorrect2()
        {
            sbyte value = -10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == -1 && result.Exponent == 1);
        }

        [Test]
        public void FromSByteCorrect3()
        {
            sbyte value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}