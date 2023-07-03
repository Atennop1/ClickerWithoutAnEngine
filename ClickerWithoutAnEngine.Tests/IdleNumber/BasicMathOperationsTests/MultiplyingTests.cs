using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class MultiplyingTests
    {
        [Test]
        public void IsMultiplyingCorrect1()
        {
            var first = new Math.IdleNumber(12);
            var second = new Math.IdleNumber(1, 27);

            var result = first.Multiply(second);
            Assert.That(result is { Number: 1.2f, Exponent: 28 });
        }
        
        [Test]
        public void IsMultiplyingCorrect2()
        {
            var first = new Math.IdleNumber(12, -12);
            var second = -100;

            var result = first.Multiply(second);
            Assert.That(result is { Number: -1.2f, Exponent: -9 });
        }
        
        [Test]
        public void IsMultiplyingCorrect3()
        {
            var first = new Math.IdleNumber(-12, -16);
            var second = new Math.IdleNumber(1, -10);
            
            var result = first.Multiply(second);
            Assert.That(result is { Number: -1.2f, Exponent: -25 });
        }
        
        [Test]
        public void IsMultiplyingCorrect4()
        {
            var first = new Math.IdleNumber(-12);
            var second = -100f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 1.2f && result.Exponent == 3);
        }
        
        [Test]
        public void IsMultiplyingCorrect5()
        {
            var first = new Math.IdleNumber();
            var second = -100f;
            
            var result = first.Multiply(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsMultiplyingCorrect6()
        {
            var first = new Math.IdleNumber();
            var second = 100f;
            
            var result = first.Multiply(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsMultiplyingCorrect7()
        {
            var first = new Math.IdleNumber(-12);
            var second = 0f;
            
            var result = first.Multiply(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsMultiplyingCorrect8()
        {
            var first = new Math.IdleNumber(12);
            var second = 0f;
            
            var result = first.Multiply(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsMultiplyingCorrect9()
        {
            var first = new Math.IdleNumber();
            var second = 0f;
            
            var result = first.Multiply(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsMultiplyingCorrect10()
        {
            var first = new Math.IdleNumber(10, 12478);
            var second = 10f;
            
            var result = first.Multiply(second);
            Assert.That(result is { Number: 1f, Exponent: 12480 });
        }
    }
}