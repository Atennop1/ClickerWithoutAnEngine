using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class ComplicatedToTestOperationsTests
    {
        [Test]
        public static void IsLessOrEqualsCorrect1()
        {
            var first = new IdleNumber(0.5f, 2);
            var second = new IdleNumber(5f, 1);
            Assert.That(first.LessOrEquals(second));
        }
        
        [Test]
        public static void IsLessOrEqualsCorrect2()
        {
            var first = new IdleNumber(1f, 2);
            var second = new IdleNumber(10f, 2);
            Assert.That(first.LessOrEquals(second));
        }

        [Test]
        public static void IsGreaterOrEqualsCorrect1() 
        {
            var first = new IdleNumber(0.5f, 2);
            var second = new IdleNumber(5f, 1);
            Assert.That(first.GreaterOrEquals(second));
        }
        
        [Test]
        public static void IsGreaterOrEqualsCorrect2() 
        {
            var first = new IdleNumber(100f, 1);
            var second = new IdleNumber(5f, 2);
            
            Assert.That(first.GreaterOrEquals(second));
        }

        [Test]
        public static void IsToBoolCorrect1() 
        {
            var value = new IdleNumber(5, 1);
            Assert.That(value.ToBool());
        }
        
        [Test]
        public static void IsToBoolCorrect2() 
        {
            var value = new IdleNumber(0, 2);
            Assert.That(!value.ToBool());
        }
    }
}