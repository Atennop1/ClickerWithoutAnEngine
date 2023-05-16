using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class IsGreaterOrEqualsTests
    {
        [Test]
        public static void IsGreaterOrEqualsCorrect1() 
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = new Math.IdleNumber(5f, 1);
            Assert.That(first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect2() 
        {
            var first = new Math.IdleNumber(100f, 1);
            var second = new Math.IdleNumber(5f, 2);
            
            Assert.That(first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect3() 
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = 50;
            Assert.That(first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect4() 
        {
            var first = new Math.IdleNumber(100f, 1);
            var second = 500;
            
            Assert.That(first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect5() 
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = 50f;
            Assert.That(first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect6() 
        {
            var first = new Math.IdleNumber(100f, 1);
            var second = 500f;
            
            Assert.That(first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect7() 
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = 60f;
            Assert.That(!first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect8() 
        {
            var first = new Math.IdleNumber(100f, 1);
            var second = 5000f;
            
            Assert.That(!first.GreaterOrEquals(second));
        }
    }
}