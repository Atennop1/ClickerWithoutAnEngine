using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.BasicMathOperationsTests
{
    public sealed class AddingTests
    {
        [Test]
        public void IsAddingCorrect1()
        {
            var first = new Math.ExponentialNumber(10);
            var second = new Math.ExponentialNumber(1, 37);
            
            var result = first.Add(second);
            Assert.That(result is { Number: 1f, Exponent: 37 });
        }
        
        [Test]
        public void IsAddingCorrect2()
        {
            var first = new Math.ExponentialNumber(10);
            var second = new Math.ExponentialNumber(-1, 15);

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 15 });
        }
        
        [Test]
        public void IsAddingCorrect3()
        {
            var first = new Math.ExponentialNumber(-1, -50);
            var second = new Math.ExponentialNumber(-1, -53);

            var result = first.Add(second);
            Assert.That(result is { Number: -1.001d, Exponent: -50 });
        }
        
        [Test]
        public void IsAddingCorrect4()
        {
            var first = new Math.ExponentialNumber(-1, -55);
            var second = -10f;

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 1 });
        }
        
        [Test]
        public void IsAddingCorrect5()
        {
            var first = new Math.ExponentialNumber(-100);
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 2 });
        }
        
        [Test]
        public void IsAddingCorrect6()
        {
            var first = new Math.ExponentialNumber();
            var second = new Math.ExponentialNumber(-1, 22);

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 22 });
        }
        
        [Test]
        public void IsAddingCorrect7()
        {
            var first = new Math.ExponentialNumber(100);
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result is { Number: 1f, Exponent: 2 });
        }
        
        [Test]
        public void IsAddingCorrect8()
        {
            var first = new Math.ExponentialNumber();
            var second = -10f;

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 1 });
        }
        
        [Test]
        public void IsAddingCorrect9()
        {
            var first = new Math.ExponentialNumber();
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
    }
}