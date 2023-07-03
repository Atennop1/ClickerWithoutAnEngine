using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber.BasicMathOperationsTests
{
    public sealed class AddingTests
    {
        [Test]
        public void IsAddingCorrect1()
        {
            var first = new Math.IdleNumber(10);
            var second = new Math.IdleNumber(1, 37);
            
            var result = first.Add(second);
            Assert.That(result is { Number: 1f, Exponent: 37 });
        }
        
        [Test]
        public void IsAddingCorrect2()
        {
            var first = new Math.IdleNumber(10);
            var second = new Math.IdleNumber(-1, 15);

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 15 });
        }
        
        [Test]
        public void IsAddingCorrect3()
        {
            var first = new Math.IdleNumber(-1, 50);
            var second = 10f;

            var result = first.Add(second);
            Assert.That(result is { Number: -1, Exponent: 50 });
        }
        
        [Test]
        public void IsAddingCorrect4()
        {
            var first = new Math.IdleNumber(-1, 55);
            var second = -10f;

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 55 });
        }
        
        [Test]
        public void IsAddingCorrect5()
        {
            var first = new Math.IdleNumber(-100);
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 2 });
        }
        
        [Test]
        public void IsAddingCorrect6()
        {
            var first = new Math.IdleNumber();
            var second = new Math.IdleNumber(-1, 22);

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 22 });
        }
        
        [Test]
        public void IsAddingCorrect7()
        {
            var first = new Math.IdleNumber(100);
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result is { Number: 1f, Exponent: 2 });
        }
        
        [Test]
        public void IsAddingCorrect8()
        {
            var first = new Math.IdleNumber();
            var second = -10f;

            var result = first.Add(second);
            Assert.That(result is { Number: -1f, Exponent: 1 });
        }
        
        [Test]
        public void IsAddingCorrect9()
        {
            var first = new Math.IdleNumber();
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
    }
}