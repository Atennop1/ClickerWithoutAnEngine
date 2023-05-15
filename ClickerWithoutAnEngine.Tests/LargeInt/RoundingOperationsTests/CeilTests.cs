using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class CeilTests
    {
        [Test]
        public void IsCeilCorrect1()
        {
            var value = new IdleNumber(512, -2);
            var result = value.Ceil();
            Assert.That(result.Number == 6f && result.Exponent == 0);
        }
        
        [Test]
        public void IsCeilCorrect2()
        {
            var value = new IdleNumber(20);
            var result = value.Ceil();
            Assert.That(result.Number == 2f && result.Exponent == 1);
        }
        
        [Test]
        public void IsCeilCorrect3()
        {
            var value = new IdleNumber(-512, -2);
            var result = value.Ceil();
            Assert.That(result.Number == -6f && result.Exponent == 0);
        }
        
        [Test]
        public void IsCeilCorrect4()
        {
            var value = new IdleNumber(-12, -1);
            var result = value.Ceil();
            Assert.That(result.Number != -1f && result.Exponent == 0);
        }
    }
}