using ClickerWithoutAnEngine.Core;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class CreationTests
    {
        [Test]
        public void IsAverageCreationCorrect()
        {
            var first = new IdleNumber(1f, 5);
            var second = new IdleNumber(100f, 5);
            var third = new IdleNumber(0.01f, 5);
            
            Assert.That(first.Number == 1f && first.Exponent == 5 &&
                        second.Number == 1f && second.Exponent == 7 &&
                        third.Number == 1f && third.Exponent == 3);
        }

        [Test]
        public void IsCreationByIdleNumberCorrect()
        {
            var first = new IdleNumber(100, 5);
            var second = new IdleNumber(first);
            Assert.That(second.Number == 1 && second.Exponent == 7);
        }
    }
}