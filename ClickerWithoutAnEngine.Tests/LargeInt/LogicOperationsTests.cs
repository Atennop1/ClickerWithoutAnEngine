using ClickerWithoutAnEngine.Core;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class LogicOperationsTests
    {
        [Test]
        public void IsEqualsCorrect()
        {
            var first = new Core.LargeInt(5, 1);
            var second = new Core.LargeInt(10, 2);
            Assert.That(first.Equals(second));
        }
        
        [Test]
        public static void IsLessCorrect() 
        {
            var first = new Core.LargeInt(10, 2);
            var second = new Core.LargeInt(10, 1);
            Assert.That(first.Less(second));
        }

        [Test]
        public static void IsLessOrEqualsCorrect() 
        {
            var first = new Core.LargeInt(10, 2);
            var second = new Core.LargeInt(5, 1);
            
            var third = new Core.LargeInt(5, 1);
            var fourth = new Core.LargeInt(10, 2);
            
            Assert.That(first.LessOrEquals(second) && third.LessOrEquals(fourth));
        }

        [Test]
        public static void IsGreaterCorrect() 
        {
            var first = new Core.LargeInt(5, 1);
            var second = new Core.LargeInt(5, 2);
            Assert.That(first.Greater(second));
        }

        [Test]
        public static void IsGreaterOrEqualsCorrect() 
        {
            var first = new Core.LargeInt(5, 1);
            var second = new Core.LargeInt(5, 2);
            
            var third = new Core.LargeInt(5, 1);
            var fourth = new Core.LargeInt(10, 2);
            
            Assert.That(first.GreaterOrEquals(second) && third.GreaterOrEquals(fourth));
        }

        [Test]
        public static void IsToBoolCorrect() 
        {
            var first = new Core.LargeInt(5, 1);
            var second = new Core.LargeInt(0, 2);
            Assert.That(first.ToBool() && !second.ToBool());
        }
    }
}