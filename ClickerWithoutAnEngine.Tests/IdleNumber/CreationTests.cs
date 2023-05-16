using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class CreationTests
    {
        [Test]
        public void IsAverageCreationCorrect1()
        {
            var value = new Math.IdleNumber(1f, 5);
            Assert.That(value.Number == 1f && value.Exponent == 5);
        }
        
        [Test]
        public void IsAverageCreationCorrect2()
        {
            var value = new Math.IdleNumber(100f, 5);
            Assert.That(value.Number == 1f && value.Exponent == 7);
        }
        
        [Test]
        public void IsAverageCreationCorrect3()
        {
            var value = new Math.IdleNumber(0.04f, 5);
            Assert.That(System.Math.Round(value.Number) == 4f && value.Exponent == 3);
        }

        [Test]
        public void IsCreationByIdleNumberCorrect()
        {
            var first = new Math.IdleNumber(100, 5);
            var second = new Math.IdleNumber(first);
            Assert.That(second.Number == 1 && second.Exponent == 7);
        }
    }
}