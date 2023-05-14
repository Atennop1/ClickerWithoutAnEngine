using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class LogicOperationsTests
    {
        [Test]
        public void IsEqualsCorrect()
        {
            var first = new IdleNumber(0.5f, 2);
            var second = new IdleNumber(5f, 1);
            Assert.That(first.Equals(second));
        }
        
        [Test]
        public static void IsLessCorrect() 
        {
            var first = new IdleNumber(1f, 2);
            var second = new IdleNumber(10f, 2);
            Assert.That(first.Less(second));
        }

        [Test]
        public static void IsLessOrEqualsCorrect() 
        {
            var first = new IdleNumber(0.5f, 2);
            var second = new IdleNumber(5f, 1);
            
            var third = new IdleNumber(1f, 2);
            var fourth = new IdleNumber(10f, 2);
            
            Assert.That(first.LessOrEquals(second) && third.LessOrEquals(fourth));
        }

        [Test]
        public static void IsGreaterCorrect() 
        {
            var first = new IdleNumber(100f, 1);
            var second = new IdleNumber(5f, 2);
            Assert.That(first.Greater(second));
        }

        [Test]
        public static void IsGreaterOrEqualsCorrect() 
        {
            var first = new IdleNumber(0.5f, 2);
            var second = new IdleNumber(5f, 1);
            
            var third = new IdleNumber(100f, 1);
            var fourth = new IdleNumber(5f, 2);
            
            Assert.That(first.GreaterOrEquals(second) && third.GreaterOrEquals(fourth));
        }

        [Test]
        public static void IsToBoolCorrect() 
        {
            var first = new IdleNumber(5, 1);
            var second = new IdleNumber(0, 2);
            Assert.That(first.ToBool() && !second.ToBool());
        }
    }
}