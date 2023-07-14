using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.LogicOperationsTests
{
    public sealed class IsGreaterTests
    {
        [Test]
        public static void IsGreaterCorrect1() 
        {
            var first = new Math.ExponentialNumber(1000);
            var second = new Math.ExponentialNumber(500);
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect2() 
        {
            var first = new Math.ExponentialNumber(100f);
            var second = -100f;
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect3() 
        {
            var first = new Math.ExponentialNumber(-1000);
            var second = -5000f;
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect4() 
        {
            var first = new Math.ExponentialNumber();
            var second = -100f;
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect5() 
        {
            var first = new Math.ExponentialNumber(100);
            var second = new Math.ExponentialNumber(5000);
            Assert.That(!first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect6() 
        {
            var first = new Math.ExponentialNumber(-100f);
            var second = new Math.ExponentialNumber(2147483647);
            Assert.That(!first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect7() 
        {
            var first = new Math.ExponentialNumber(-1000);
            var second = -500f;
            Assert.That(!first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect8() 
        {
            var first = new Math.ExponentialNumber();
            var second = 100f;
            Assert.That(!first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect9() 
        {
            var first = new Math.ExponentialNumber(30);
            var second = new Math.ExponentialNumber();
            Assert.That(first.Greater(second));
        }
        
        [Test]
        public static void IsGreaterCorrect10() 
        {
            var first = new Math.ExponentialNumber(-30);
            var second = new Math.ExponentialNumber();
            Assert.That(!first.Greater(second));
        }
    }
}