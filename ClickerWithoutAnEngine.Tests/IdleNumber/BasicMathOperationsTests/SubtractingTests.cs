using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class SubtractingTests
    {
        [Test]
        public void IsSubtractingCorrect1()
        {
            var first = new Math.IdleNumber(10);
            var second = new Math.IdleNumber(100);

            var result = first.Subtract(second);
            Assert.That(result.Number == -9f && result.Exponent == 1);
        }
        
        [Test]
        public void IsSubtractingCorrect2()
        {
            var first = new Math.IdleNumber(-10);
            var second = 100;

            var result = first.Subtract(second);
            Assert.That(result.Number == -1.1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsSubtractingCorrect3()
        {
            var first = new Math.IdleNumber(10);
            var second = -100f;

            var result = first.Subtract(second);
            Assert.That(result.Number == 1.1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsSubtractingCorrectSecond4()
        {
            var first = new Math.IdleNumber(-10);
            var second = new Math.IdleNumber(-100);

            var result = first.Subtract(second);
            Assert.That(result.Number == 9f && result.Exponent == 1);
        }
        
        [Test]
        public void IsSubtractingCorrectSecond5()
        {
            var first = new Math.IdleNumber();
            var second = new Math.IdleNumber(100);

            var result = first.Subtract(second);
            Assert.That(result.Number == -1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsSubtractingCorrectSecond6()
        {
            var first = new Math.IdleNumber();
            var second = new Math.IdleNumber(-100);

            var result = first.Subtract(second);
            Assert.That(result.Number == 1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsSubtractingCorrectSecond7()
        {
            var first = new Math.IdleNumber(10);
            var second = new Math.IdleNumber();

            var result = first.Subtract(second);
            Assert.That(result.Number == 1f && result.Exponent == 1);
        }
        
        [Test]
        public void IsSubtractingCorrectSecond8()
        {
            var first = new Math.IdleNumber(-10);
            var second = new Math.IdleNumber();

            var result = first.Subtract(second);
            Assert.That(result.Number == -1f && result.Exponent == 1);
        }
        
        [Test]
        public void IsSubtractingCorrectSecond9()
        {
            var first = new Math.IdleNumber();
            var second = new Math.IdleNumber();

            var result = first.Subtract(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
    }
}