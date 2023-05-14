using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class MultiplyingTests
    {
        [Test]
        public void IsMultiplyingCorrect1()
        {
            var first = new IdleNumber(12);
            var second = new IdleNumber(100);

            var result = first.Multiply(second);
            Assert.That(result.Number == 1.2f && result.Exponent == 3);
        }
        
        [Test]
        public void IsMultiplyingCorrect2()
        {
            var first = new IdleNumber(12);
            var second = -100;

            var result = first.Multiply(second);
            Assert.That(result.Number == -1.2f && result.Exponent == 3);
        }
        
        [Test]
        public void IsMultiplyingCorrect3()
        {
            var first = new IdleNumber(-12);
            var second = 100f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == -1.2f && result.Exponent == 3);
        }
        
        [Test]
        public void IsMultiplyingCorrect4()
        {
            var first = new IdleNumber(-12);
            var second = -100f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 1.2f && result.Exponent == 3);
        }
        
        [Test]
        public void IsMultiplyingCorrect5()
        {
            var first = new IdleNumber();
            var second = -100f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsMultiplyingCorrect6()
        {
            var first = new IdleNumber();
            var second = 100f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsMultiplyingCorrect7()
        {
            var first = new IdleNumber(-12);
            var second = 0f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsMultiplyingCorrect8()
        {
            var first = new IdleNumber(12);
            var second = 0f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsMultiplyingCorrect9()
        {
            var first = new IdleNumber();
            var second = 0f;
            
            var result = first.Multiply(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
    }
}