using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Int
{
    public sealed class ToIntTests
    {
        [Test]
        public void ToIntCorrect1()
        {
            var idleNumber = new Math.ExponentialNumber(1, 20);
            Assert.Throws<OverflowException>(() => idleNumber.ToInt());
        }
        
        [Test]
        public void ToIntCorrect2()
        {
            var idleNumber = new Math.ExponentialNumber(-1, 20);
            Assert.Throws<OverflowException>(() => idleNumber.ToInt());
        }
        
        [Test]
        public void ToIntCorrect3()
        {
            var idleNumber = new Math.ExponentialNumber(100);
            Assert.That(idleNumber.ToInt() == 100);
        }
        
        [Test]
        public void ToIntCorrect4()
        {
            var idleNumber = new Math.ExponentialNumber(-100);
            Assert.That(idleNumber.ToInt() == -100);
        }
        
        [Test]
        public void ToIntCorrect5()
        {
            var idleNumber = new Math.ExponentialNumber();
            Assert.That(idleNumber.ToInt() == 0);
        }
    }
}