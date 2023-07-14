using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.SpecificMathOperationsTests
{
    public sealed class AbsTests
    {
        [Test]
        public void IsAbsCorrect1()
        {
            var value = new Math.ExponentialNumber(10, -2);
            var result = value.Abs();
            Assert.That(result is { Number: 1, Exponent: -1 });
        }
        
        [Test]
        public void IsAbsCorrect2()
        {
            var value = new Math.ExponentialNumber(-10, 2);
            var result = value.Abs();
            Assert.That(result is { Number: 1, Exponent: 3 });
        }
        
        [Test]
        public void IsAbsCorrect3()
        {
            var value = new Math.ExponentialNumber();
            var result = value.Abs();
            Assert.That(result is { Number: 0, Exponent: 0 });
        }
    }
}