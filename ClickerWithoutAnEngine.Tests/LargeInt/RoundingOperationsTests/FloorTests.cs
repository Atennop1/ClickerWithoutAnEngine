using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class FloorTests
    {
        [Test]
        public void IsFloorCorrect1()
        {
            var value = new IdleNumber(512, -2);
            var result = value.Floor();
            Assert.That(result.Number == 5f && result.Exponent == 0);
        }
        
        [Test]
        public void IsFloorCorrect2()
        {
            var value = new IdleNumber(2, 1);
            var result = value.Floor();
            Assert.That(result.Number == 2f && result.Exponent == 1);
        }
        
        [Test]
        public void IsFloorCorrect3()
        {
            var value = new IdleNumber(-512, -2);
            var result = value.Floor();
            Assert.That(result.Number == -5f && result.Exponent == 0);
        }
        
        [Test]
        public void IsFloorCorrect4()
        {
            var value = new IdleNumber(-12, -1);
            var result = value.Floor();
            Assert.That(result.Number != -2f && result.Exponent == 0);
        }
    }
}