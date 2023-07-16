using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Double
{
    public sealed class ToDoubleTests
    {
        [Test]
        public void ToDoubleCorrect1()
        {
            var idleNumber = new Math.ExponentialNumber(1, 2000);
            Assert.Throws<OverflowException>(() => idleNumber.ToDouble());
        }
        
        [Test]
        public void ToDoubleCorrect2()
        {
            var idleNumber = new Math.ExponentialNumber(-1, 2000);
            Assert.Throws<OverflowException>(() => idleNumber.ToDouble());
        }
        
        [Test]
        public void ToDoubleCorrect3()
        {
            var idleNumber = new Math.ExponentialNumber(100);
            Assert.That(idleNumber.ToDouble() == 100D);
        }
        
        [Test]
        public void ToDoubleCorrect4()
        {
            var idleNumber = new Math.ExponentialNumber(-100);
            Assert.That(idleNumber.ToDouble() == -100D);
        }
        
        [Test]
        public void ToDoubleCorrect5()
        {
            var idleNumber = new Math.ExponentialNumber();
            Assert.That(idleNumber.ToDouble() == 0D);
        }
    }
}