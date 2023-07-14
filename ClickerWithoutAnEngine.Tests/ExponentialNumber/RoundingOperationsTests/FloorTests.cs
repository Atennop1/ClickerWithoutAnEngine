using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.RoundingOperationsTests
{
    public sealed class FloorTests
    {
        [Test]
        public void IsFloorCorrect1()
        {
            var value = new Math.ExponentialNumber(512, -2);
            var result = value.Floor();
            Assert.That(result is { Number: 5f, Exponent: 0 });
        }
        
        [Test]
        public void IsFloorCorrect2()
        {
            var value = new Math.ExponentialNumber(2, 1);
            var result = value.Floor();
            Assert.That(result is { Number: 2f, Exponent: 1 });
        }
        
        [Test]
        public void IsFloorCorrect3()
        {
            var value = new Math.ExponentialNumber(-512, -2);
            var result = value.Floor();
            Assert.That(result is { Number: -6f, Exponent: 0 });
        }
        
        [Test]
        public void IsFloorCorrect4()
        {
            var value = new Math.ExponentialNumber(-12, -1);
            var result = value.Floor();
            Assert.That(result is { Number: -2f, Exponent: 0 });
        }
        
        [Test]
        public void IsFloorCorrect5()
        {
            var value = new Math.ExponentialNumber();
            var result = value.Floor();
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
    }
}