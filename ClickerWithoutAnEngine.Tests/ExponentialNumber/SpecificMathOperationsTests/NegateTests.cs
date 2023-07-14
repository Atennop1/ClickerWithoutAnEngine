using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.SpecificMathOperationsTests
{
    public sealed class NegateTests
    {
        [Test]
        public void IsNegateCorrect1()
        {
            var first = new Math.ExponentialNumber(10, -2);
            var result = first.Negate();
            Assert.That(result is { Number: -1, Exponent: -1 });
        }
        
        [Test]
        public void IsNegateCorrect2()
        {
            var value = new Math.ExponentialNumber(-10, 2);
            var result = value.Negate();
            Assert.That(result is { Number: 1, Exponent: 3 });
        }
        
        [Test]
        public void IsNegateCorrect3()
        {
            var value = new Math.ExponentialNumber();
            var result = value.Negate();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}