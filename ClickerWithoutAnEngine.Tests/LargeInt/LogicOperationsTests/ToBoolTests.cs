using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class ToBoolTests
    {
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