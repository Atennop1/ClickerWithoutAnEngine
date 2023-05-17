using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class FromIntTests
    {
        [Test]
        public void FromIntCorrect1()
        {
            int value = 10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 1 && result.Exponent == 1);
        }
        
        [Test]
        public void FromIntCorrect2()
        {
            int value = -10;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == -1 && result.Exponent == 1);
        }

        [Test]
        public void FromIntCorrect3()
        {
            int value = 0;
            var result = value.ToIdleNumber();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}