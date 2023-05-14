using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class SimpleToTestOperationsTests
    {
        [Test]
        public void IsEqualsCorrect()
        {
            var first = new IdleNumber(0.5f, 2);
            var second = new IdleNumber(5f, 1);
            Assert.That(first.IsEquals(second));
        }
        
        [Test]
        public static void IsLessCorrect() 
        {
            var first = new IdleNumber(1f, 2);
            var second = new IdleNumber(10f, 2);
            Assert.That(first.Less(second));
        }

        [Test]
        public static void IsGreaterCorrect() 
        {
            var first = new IdleNumber(100f, 1);
            var second = new IdleNumber(5f, 2);
            Assert.That(first.Greater(second));
        }
    }
}