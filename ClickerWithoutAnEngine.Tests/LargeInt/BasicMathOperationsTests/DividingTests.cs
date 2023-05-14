using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class DividingTests
    {
        [Test]
        public void IsDividingCorrect1()
        {
            var first = new IdleNumber(12);
            var second = new IdleNumber(100);

            var result = first.Divide(second);
            Assert.That(result.Number == 1.2f && result.Exponent == -1);
        }
        
        [Test]
        public void IsDividingCorrect2()
        {
            var first = new IdleNumber(12);
            var second = -100;

            var result = first.Divide(second);
            Assert.That(result.Number == -1.2f && result.Exponent == -1);
        }
        
        [Test]
        public void IsDividingCorrect3()
        {
            var first = new IdleNumber(-12);
            var second = 100f;

            var result = first.Divide(second);
            Assert.That(result.Number == -1.2f && result.Exponent == -1);
        }
        
        [Test]
        public void IsDividingCorrect4()
        {
            var first = new IdleNumber(-12);
            var second = -100f;

            var result = first.Divide(second);
            Assert.That(result.Number == 1.2f && result.Exponent == -1);
        }
        
        [Test]
        public void IsDividingCorrect5()
        {
            var first = new IdleNumber();
            var second = -100f;

            var result = first.Divide(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsDividingCorrect6()
        {
            var first = new IdleNumber();
            var second = 100f;

            var result = first.Divide(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
    }
}