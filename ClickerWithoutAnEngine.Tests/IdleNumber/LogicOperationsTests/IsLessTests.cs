using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class IsLessTests
    {
        [Test]
        public static void IsLessCorrect1() 
        {
            var first = new Math.IdleNumber(100);
            var second = new Math.IdleNumber(1000);
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect2() 
        {
            var first = new Math.IdleNumber(-100000);
            var second = 1000;
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect3() 
        {
            var first = new Math.IdleNumber(-100);
            var second = -10f;
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect4() 
        {
            var first = new Math.IdleNumber();
            var second = 50;
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect5() 
        {
            var first = new Math.IdleNumber(100);
            var second = new Math.IdleNumber(-1000);
            Assert.That(!first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect6() 
        {
            var first = new Math.IdleNumber(100000);
            var second = 1000;
            Assert.That(!first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect7() 
        {
            var first = new Math.IdleNumber(100);
            var second = -10f;
            Assert.That(!first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect8() 
        {
            var first = new Math.IdleNumber();
            var second = -50;
            Assert.That(!first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect9() 
        {
            var first = new Math.IdleNumber(-20);
            var second = new Math.IdleNumber();
            Assert.That(first.Less(second));
        }
        
        [Test]
        public static void IsLessCorrect10() 
        {
            var first = new Math.IdleNumber(20);
            var second = new Math.IdleNumber();
            Assert.That(!first.Less(second));
        }
    }
}