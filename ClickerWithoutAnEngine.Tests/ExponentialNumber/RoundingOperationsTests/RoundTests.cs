using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.RoundingOperationsTests
{
    public sealed class RoundTests
    {
        [Test]
        public void IsRoundCorrect1()
        {
            var value = new Math.ExponentialNumber(512, -2);
            var result = value.Round();
            Assert.That(result is { Number: 5f, Exponent: 0 });
        }
        
        [Test]
        public void IsRoundCorrect2()
        {
            var value = new Math.ExponentialNumber(20);
            var result = value.Round();
            Assert.That(result is { Number: 2f, Exponent: 1 });
        }
        
        [Test]
        public void IsRoundCorrect3()
        {
            var value = new Math.ExponentialNumber(-550, -2);
            var result = value.Round();
            Assert.That(result is { Number: -5f, Exponent: 0 });
        }
        
        [Test]
        public void IsRoundCorrect4()
        {
            var value = new Math.ExponentialNumber(-560, -2);
            var result = value.Round();
            Assert.That(result is { Number: -6f, Exponent: 0 });
        }
        
        [Test]
        public void IsRoundCorrect5()
        {
            var value = new Math.ExponentialNumber(26);
            var result = value.Round();
            Assert.That(result is { Number: 3f, Exponent: 1 });
        }
        
        [Test]
        public void IsRoundCorrect6()
        {
            var value = new Math.ExponentialNumber(18);
            var result = value.Round();
            Assert.That(result is { Number: 2f, Exponent: 1 });
        }
        
        [Test]
        public void IsRoundCorrect7()
        {
            var value = new Math.ExponentialNumber(55, -1);
            var result = value.Round();
            Assert.That(result is { Number: 6f, Exponent: 0 });
        }
    }
}