using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class RemainderTests
    {
        [Test]
        public void IsRemainderCorrect1()
        {
            var first = new IdleNumber(5);
            var second = new IdleNumber(2);

            var result = first.Remainder(second);
            Assert.That(result.Number == 1f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRemainderCorrect2()
        {
            var first = new IdleNumber(5);
            var second = -2;

            var result = first.Remainder(second);
            Assert.That(result.Number == 1f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRemainderCorrect3()
        {
            var first = new IdleNumber(-5);
            var second = 2f;

            var result = first.Remainder(second);
            Assert.That(result.Number == -1f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRemainderCorrect4()
        {
            var first = new IdleNumber(-5);
            var second = -2f;

            var result = first.Remainder(second);
            Assert.That(result.Number == -1f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRemainderCorrect5()
        {
            var first = new IdleNumber();
            var second = -2f;

            var result = first.Remainder(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRemainderCorrect6()
        {
            var first = new IdleNumber();
            var second = 2f;

            var result = first.Remainder(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
    }
}