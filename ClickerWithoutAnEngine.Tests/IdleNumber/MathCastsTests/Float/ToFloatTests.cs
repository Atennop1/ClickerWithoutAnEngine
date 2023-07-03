using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber.MathCastsTests.Float
{
    public sealed class ToFloatTests
    {
        [Test]
        public void ToFloatCorrect1()
        {
            var idleNumber = new Math.IdleNumber(1, 200);
            Assert.Throws<OverflowException>(() => idleNumber.ToFloat());
        }
        
        [Test]
        public void ToFloatCorrect2()
        {
            var idleNumber = new Math.IdleNumber(-1, 200);
            Assert.Throws<OverflowException>(() => idleNumber.ToFloat());
        }
        
        [Test]
        public void ToFloatCorrect3()
        {
            var idleNumber = new Math.IdleNumber(100);
            Assert.That(idleNumber.ToFloat() == 100);
        }
        
        [Test]
        public void ToFloatCorrect4()
        {
            var idleNumber = new Math.IdleNumber(-100);
            Assert.That(idleNumber.ToFloat() == -100);
        }
        
        [Test]
        public void ToFloatCorrect5()
        {
            var idleNumber = new Math.IdleNumber();
            Assert.That(idleNumber.ToFloat() == 0);
        }
    }
}