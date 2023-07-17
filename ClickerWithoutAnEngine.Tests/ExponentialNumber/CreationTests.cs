using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber
{
    public sealed class CreationTests
    {
        [Test]
        public void IsAverageCreationCorrect1()
        {
            var value = new Math.ExponentialNumber(1f, 5);
            Assert.That(value is { Number: 1f, Exponent: 5 });
        }
        
        [Test]
        public void IsAverageCreationCorrect2()
        {
            var value = new Math.ExponentialNumber(100f, 5);
            Assert.That(value is { Number: 1f, Exponent: 7 });
        }
        
        [Test]
        public void IsAverageCreationCorrect3()
        {
            var value = new Math.ExponentialNumber(0.04f, 5);
            Assert.That(System.Math.Round(value.Number) == 4f && value.Exponent == 3);
        }

        [Test]
        public void IsCreationByExponentialNumberCorrect()
        {
            var first = new Math.ExponentialNumber(100, 5);
            var second = new Math.ExponentialNumber(first);
            Assert.That(second is { Number: 1, Exponent: 7 });
        }
    }
}