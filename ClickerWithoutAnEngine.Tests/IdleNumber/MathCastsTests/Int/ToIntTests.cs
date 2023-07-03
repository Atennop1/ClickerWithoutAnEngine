using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber.MathCastsTests.Int
{
    public sealed class ToIntTests
    {
        [Test]
        public void ToIntCorrect1()
        {
            var idleNumber = new Math.IdleNumber(1, 20);
            Assert.Throws<OverflowException>(() => idleNumber.ToInt());
        }
        
        [Test]
        public void ToIntCorrect2()
        {
            var idleNumber = new Math.IdleNumber(-1, 20);
            Assert.Throws<OverflowException>(() => idleNumber.ToInt());
        }
        
        [Test]
        public void ToIntCorrect3()
        {
            var idleNumber = new Math.IdleNumber(100);
            Assert.That(idleNumber.ToInt() == 100);
        }
        
        [Test]
        public void ToIntCorrect4()
        {
            var idleNumber = new Math.IdleNumber(-100);
            Assert.That(idleNumber.ToInt() == -100);
        }
        
        [Test]
        public void ToIntCorrect5()
        {
            var idleNumber = new Math.IdleNumber();
            Assert.That(idleNumber.ToInt() == 0);
        }
    }
}