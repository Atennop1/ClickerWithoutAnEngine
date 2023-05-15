using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class IsLessTests
    {
        [Test]
        public static void IsLessCorrect1() 
        {
            var first = new IdleNumber(1f, 2);
            var second = new IdleNumber(10f, 2);
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect2() 
        {
            var first = new IdleNumber(1f, 2);
            var second = 1000;
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect3() 
        {
            var first = new IdleNumber(1f, 2);
            var second = 1000f;
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect4() 
        {
            var first = new IdleNumber(1f, 2);
            var second = 50;
            Assert.That(!first.Less(second));
        }
    }
}