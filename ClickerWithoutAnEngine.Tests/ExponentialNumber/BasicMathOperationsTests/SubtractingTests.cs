using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.BasicMathOperationsTests
{
    public sealed class SubtractingTests
    {
        [Test]
        public void IsSubtractingCorrect1()
        {
            var first = new Math.ExponentialNumber(10);
            var second = new Math.ExponentialNumber(1, 13);

            var result = first.Subtract(second);
            Assert.That(result is { Number: -1f, Exponent: 13 });
        }
        
        [Test]
        public void IsSubtractingCorrect2()
        {
            var first = new Math.ExponentialNumber(-1, 16);
            var second = 100;

            var result = first.Subtract(second);
            Assert.That(result is { Number: -1f, Exponent: 16 });
        }
        
        [Test]
        public void IsSubtractingCorrect3()
        {
            var first = new Math.ExponentialNumber(10);
            var second = new Math.ExponentialNumber(-1, 27);

            var result = first.Subtract(second);
            Assert.That(result is { Number: 1f, Exponent: 27 });
        }
        
        [Test]
        public void IsSubtractingCorrectSecond4()
        {
            var first = new Math.ExponentialNumber(1, 16);
            var second = new Math.ExponentialNumber(-100);

            var result = first.Subtract(second);
            Assert.That(result is { Number: 1f, Exponent: 16 });
        }
        
        [Test]
        public void IsSubtractingCorrectSecond5()
        {
            var first = new Math.ExponentialNumber();
            var second = new Math.ExponentialNumber(100);

            var result = first.Subtract(second);
            Assert.That(result is { Number: -1f, Exponent: 2 });
        }
        
        [Test]
        public void IsSubtractingCorrectSecond6()
        {
            var first = new Math.ExponentialNumber();
            var second = new Math.ExponentialNumber(-100);

            var result = first.Subtract(second);
            Assert.That(result is { Number: 1f, Exponent: 2 });
        }
        
        [Test]
        public void IsSubtractingCorrectSecond7()
        {
            var first = new Math.ExponentialNumber(10);
            var second = new Math.ExponentialNumber();

            var result = first.Subtract(second);
            Assert.That(result is { Number: 1f, Exponent: 1 });
        }
        
        [Test]
        public void IsSubtractingCorrectSecond8()
        {
            var first = new Math.ExponentialNumber(-10);
            var second = new Math.ExponentialNumber();

            var result = first.Subtract(second);
            Assert.That(result is { Number: -1f, Exponent: 1 });
        }
        
        [Test]
        public void IsSubtractingCorrectSecond9()
        {
            var first = new Math.ExponentialNumber();
            var second = new Math.ExponentialNumber();

            var result = first.Subtract(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
    }
}