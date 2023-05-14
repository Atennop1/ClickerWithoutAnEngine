using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class AddingTests
    {
        [Test]
        public void IsAddingCorrect1()
        {
            var first = new IdleNumber(10);
            var second = new IdleNumber(10, 1);
            
            var result = first.Add(second);
            Assert.That(result.Number == 1.1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsAddingCorrect2()
        {
            var first = new IdleNumber(10);
            var second = 100;

            var result = first.Add(second);
            Assert.That(result.Number == 1.1f && result.Exponent == 2);
        }
        
        [Test]
        public void IsAddingCorrect3()
        {
            var first = new IdleNumber(-100);
            var second = 10f;

            var result = first.Add(second);
            Assert.That(result.Number == -9 && result.Exponent == 1);
        }
    }
}