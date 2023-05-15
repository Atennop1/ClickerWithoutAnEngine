using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class RoundTests
    {
        [Test]
        public void IsRoundCorrect1()
        {
            var value = new IdleNumber(512, -2);
            var result = value.Round();
            Assert.That(result.Number == 5f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRoundCorrect2()
        {
            var value = new IdleNumber(20);
            var result = value.Round();
            Assert.That(result.Number == 2f && result.Exponent == 1);
        }
        
        [Test]
        public void IsRoundCorrect3()
        {
            var value = new IdleNumber(-550, -2);
            var result = value.Round();
            Assert.That(result.Number == -6f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRoundCorrect4()
        {
            var value = new IdleNumber(-560, -2);
            var result = value.Round();
            Assert.That(result.Number == -6f && result.Exponent == 0);
        }
        
        [Test]
        public void IsRoundCorrect5()
        {
            var value = new IdleNumber(26);
            var result = value.Round();
            Assert.That(result.Number != 2f && result.Exponent == 1);
        }
        
        [Test]
        public void IsRoundCorrect6()
        {
            var value = new IdleNumber(18);
            var result = value.Round();
            Assert.That(result.Number != 1f && result.Exponent == 1);
        }
    }
}