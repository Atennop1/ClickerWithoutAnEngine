using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class IsLessOrEqualsTests
    {
        [Test]
        public static void IsLessOrEqualsCorrect1()
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = new Math.IdleNumber(5f, 1);
            Assert.That(first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect2()
        {
            var first = new Math.IdleNumber(1f, 2);
            var second = new Math.IdleNumber(10f, 2);
            Assert.That(first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect3()
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = 50;
            Assert.That(first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect4()
        {
            var first = new Math.IdleNumber(1f, 2);
            var second = 1000;
            Assert.That(first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect5()
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = 50f;
            Assert.That(first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect6()
        {
            var first = new Math.IdleNumber(1f, 2);
            var second = 1000f;
            Assert.That(first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect7()
        {
            var first = new Math.IdleNumber(0.5f, 2);
            var second = 40f;
            Assert.That(!first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect8()
        {
            var first = new Math.IdleNumber(1f, 2);
            var second = 60f;
            Assert.That(!first.LessOrEquals(second));
        }
    }
}