using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.MathCastsTests.Int
{
    public sealed class ToIntTests
    {
        [Test]
        public void ToIntCorrect1()
        {
            var exponentialNumber = new Math.ExponentialNumber(1, 20);
            Assert.Throws<OverflowException>(() => exponentialNumber.ToInt());
        }
        
        [Test]
        public void ToIntCorrect2()
        {
            var exponentialNumber = new Math.ExponentialNumber(-1, 20);
            Assert.Throws<OverflowException>(() => exponentialNumber.ToInt());
        }
        
        [Test]
        public void ToIntCorrect3()
        {
            var exponentialNumber = new Math.ExponentialNumber(100);
            Assert.That(exponentialNumber.ToInt() == 100);
        }
        
        [Test]
        public void ToIntCorrect4()
        {
            var exponentialNumber = new Math.ExponentialNumber(-100);
            Assert.That(exponentialNumber.ToInt() == -100);
        }
        
        [Test]
        public void ToIntCorrect5()
        {
            var exponentialNumber = new Math.ExponentialNumber();
            Assert.That(exponentialNumber.ToInt() == 0);
        }
    }
}