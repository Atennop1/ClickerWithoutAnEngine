using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Double
{
    public sealed class ToDoubleTests
    {
        [Test]
        public void ToDoubleCorrect1()
        {
            var exponentialNumber = new Math.ExponentialNumber(1, 2000);
            Assert.Throws<OverflowException>(() => exponentialNumber.ToDouble());
        }
        
        [Test]
        public void ToDoubleCorrect2()
        {
            var exponentialNumber = new Math.ExponentialNumber(-1, 2000);
            Assert.Throws<OverflowException>(() => exponentialNumber.ToDouble());
        }
        
        [Test]
        public void ToDoubleCorrect3()
        {
            var exponentialNumber = new Math.ExponentialNumber(100);
            Assert.That(exponentialNumber.ToDouble() == 100D);
        }
        
        [Test]
        public void ToDoubleCorrect4()
        {
            var exponentialNumber = new Math.ExponentialNumber(-100);
            Assert.That(exponentialNumber.ToDouble() == -100D);
        }
        
        [Test]
        public void ToDoubleCorrect5()
        {
            var exponentialNumber = new Math.ExponentialNumber();
            Assert.That(exponentialNumber.ToDouble() == 0D);
        }
    }
}