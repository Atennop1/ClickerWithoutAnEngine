using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class IsGreaterTests
    {
        [Test]
        public static void IsGreaterCorrect1() 
        {
            var first = new IdleNumber(100f, 1);
            var second = new IdleNumber(5f, 2);
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect2() 
        {
            var first = new IdleNumber(100f, 1);
            var second = 500;
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect3() 
        {
            var first = new IdleNumber(100f, 1);
            var second = 500f;
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect4() 
        {
            var first = new IdleNumber(100f, 1);
            var second = 5000f;
            Assert.That(!first.Greater(second));
        }
    }
}