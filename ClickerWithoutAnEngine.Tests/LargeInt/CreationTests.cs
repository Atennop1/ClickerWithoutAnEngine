using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class CreationTests
    {
        [Test]
        public void IsAverageCreationCorrect1()
        {
            var value = new IdleNumber(1f, 5);
            Assert.That(value.Number == 1f && value.Exponent == 5);
        }
        
        [Test]
        public void IsAverageCreationCorrect2()
        {
            var value = new IdleNumber(100f, 5);
            Assert.That(value.Number == 1f && value.Exponent == 7);
        }
        
        [Test]
        public void IsAverageCreationCorrect3()
        {
            var value = new IdleNumber(0.01f, 5);
            Assert.That(value.Number == 1f && value.Exponent == 3);
        }

        [Test]
        public void IsCreationByIdleNumberCorrect()
        {
            var first = new IdleNumber(100, 5);
            var second = new IdleNumber(first);
            Assert.That(second.Number == 1 && second.Exponent == 7);
        }
    }
}