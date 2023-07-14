using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.SpecificMathOperationsTests
{
    public sealed class InverseTests
    {
        [Test]
        public void IsInverseCorrect1()
        {
            var value = new Math.ExponentialNumber(10, -2);
            var result = value.Inverse();
            Assert.That(result is { Number: 1, Exponent: 1 });
        }
        
        [Test]
        public void IsInverseCorrect2()
        {
            var value = new Math.ExponentialNumber(-10, 2);
            var result = value.Inverse();
            Assert.That(result is { Number: -1, Exponent: -3 });
        }
        
        [Test]
        public void IsInverseCorrect3()
        {
            var value = new Math.ExponentialNumber();
            var result = value.Inverse();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}