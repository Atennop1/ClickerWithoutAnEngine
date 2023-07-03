using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber.BasicMathOperationsTests
{
    public sealed class PowTests
    {
        [Test]
        public void IsPowCorrect1()
        {
            var first = new Math.IdleNumber(5);
            var second = 2;
            
            var result = first.Pow(second);
            Assert.That(result is { Number: 2.5f, Exponent: 1 });
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
            Assert.That(result is { Number: 2.5f, Exponent: 1 });
        }
        
        [Test]
        public void IsPowCorrect4()
        {
            var first = new Math.IdleNumber(-5);
            var second = -2;

            var result = first.Pow(second);
            Assert.That(result is { Number: 4f, Exponent: -2 });
        }
        
        [Test]
        public void IsPowCorrect5()
        {
            var first = new Math.IdleNumber();
            var second = -1;

            var result = first.Pow(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsPowCorrect6()
        {
            var first = new Math.IdleNumber();
            var second = 1;

            var result = first.Pow(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsPowCorrect7()
        {
            var first = new Math.IdleNumber(-5);
            var second = 0;

            var result = first.Pow(second);
            Assert.That(result is { Number: 1f, Exponent: 0 });
        }
        
        [Test]
        public void IsPowCorrect8()
        {
            var first = new Math.IdleNumber(5);
            var second = 0;

            var result = first.Pow(second);
            Assert.That(result is { Number: 1f, Exponent: 0 });
        }
        
        [Test]
        public void IsPowCorrect9()
        {
            var first = new Math.IdleNumber();
            var second = 0;

            var result = first.Pow(second);
            Assert.That(result is { Number: 1f, Exponent: 0 });
        }
        
        [Test]
        public void IsPowCorrect10()
        {
            var first = new Math.IdleNumber(-5);
            var second = 1;

            var result = first.Pow(second);
            Assert.That(result is { Number: -5f, Exponent: 0 });
        }
        
        [Test]
        public void IsPowCorrect11()
        {
            var first = new Math.IdleNumber(-5);
            var second = -1;

            var result = first.Pow(second);
            Assert.That(result is { Number: -2f, Exponent: -1 });
        }
    }
}