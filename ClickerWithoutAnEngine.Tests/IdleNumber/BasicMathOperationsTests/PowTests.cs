using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class PowTests
    {
        [Test]
        public void IsPowCorrect1()
        {
            var first = new Math.IdleNumber(5);
            var second = 2;
            
            var result = first.Pow(second);
            Assert.That(result.Number == 2.5f && result.Exponent == 1);
        }
        
        [Test]
        public void IsPowCorrect2()
        {
            var first = new Math.IdleNumber(5);
            var second = -2;

            var result = first.Pow(second);
            Assert.That(System.Math.Round(result.Number) == 4f && result.Exponent == -2);
        }
        
        [Test]
        public void IsPowCorrect3()
        {
            var first = new Math.IdleNumber(-5);
            var second = 2;

            var result = first.Pow(second);
            Assert.That(result.Number == 2.5f && result.Exponent == 1);
        }
        
        [Test]
        public void IsPowCorrect4()
        {
            var first = new Math.IdleNumber(-5);
            var second = -2;

            var result = first.Pow(second);
            Assert.That(System.Math.Round(result.Number) == 4f && result.Exponent == -2);
        }
        
        [Test]
        public void IsPowCorrect5()
        {
            var first = new Math.IdleNumber();
            var second = -1;

            var result = first.Pow(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsPowCorrect6()
        {
            var first = new Math.IdleNumber();
            var second = 1;

            var result = first.Pow(second);
            Assert.That(result.Number == 0f && result.Exponent == 0);
        }
        
        [Test]
        public void IsPowCorrect7()
        {
            var first = new Math.IdleNumber(-5);
            var second = 0;

            var result = first.Pow(second);
            Assert.That(result.Number == 1f && result.Exponent == 0);
        }
        
        [Test]
        public void IsPowCorrect8()
        {
            var first = new Math.IdleNumber(5);
            var second = 0;

            var result = first.Pow(second);
            Assert.That(result.Number == 1f && result.Exponent == 0);
        }
        
        [Test]
        public void IsPowCorrect9()
        {
            var first = new Math.IdleNumber();
            var second = 0;

            var result = first.Pow(second);
            Assert.That(result.Number == 1f && result.Exponent == 0);
        }
        
        [Test]
        public void IsPowCorrect10()
        {
            var first = new Math.IdleNumber(-5);
            var second = 1;

            var result = first.Pow(second);
            Assert.That(result.Number == -5f && result.Exponent == 0);
        }
        
        [Test]
        public void IsPowCorrect11()
        {
            var first = new Math.IdleNumber(-5);
            var second = -1;

            var result = first.Pow(second);
            Assert.That(result.Number == -2f && result.Exponent == -1);
        }
    }
}