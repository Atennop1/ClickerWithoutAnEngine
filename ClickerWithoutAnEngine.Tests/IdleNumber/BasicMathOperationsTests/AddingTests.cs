using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class AddingTests
    {
        [Test]
        public void IsAddingCorrect1()
        {
            var first = new Math.IdleNumber(10);
            var second = new Math.IdleNumber(10, 1);
            
            var result = first.Add(second);
            Assert.That(result.Number == 1.1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsAddingCorrect2()
        {
            var first = new Math.IdleNumber(10);
            var second = -100;

            var result = first.Add(second);
            Assert.That(result.Number == -9f && result.Exponent == 1);
        }
        
        [Test]
        public void IsAddingCorrect3()
        {
            var first = new Math.IdleNumber(-100);
            var second = 10f;

            var result = first.Add(second);
            Assert.That(result.Number == -9 && result.Exponent == 1);
        }
        
        [Test]
        public void IsAddingCorrect4()
        {
            var first = new Math.IdleNumber(-100);
            var second = -10f;

            var result = first.Add(second);
            Assert.That(result.Number == -1.1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsAddingCorrect5()
        {
            var first = new Math.IdleNumber(-100);
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result.Number == -1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsAddingCorrect6()
        {
            var first = new Math.IdleNumber();
            var second = -10f;

            var result = first.Add(second);
            Assert.That(result.Number == -1f && result.Exponent == 1);
        }
        
        [Test]
        public void IsAddingCorrect7()
        {
            var first = new Math.IdleNumber(100);
            var second = 0f;

            var result = first.Add(second);
            Assert.That(result.Number == 1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsAddingCorrect8()
        {
            var first = new Math.IdleNumber();
            var second = 10f;

            var result = first.Add(second);
            Assert.That(result.Number == 1f && result.Exponent == 1);
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