using ClickerWithoutAnEngine.Core;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class RoundingMathOperationsTests
    {
        [Test]
        public void IsFloorCorrect()
        {
            var first = new Core.LargeInt(5, 2);
            var second = new Core.LargeInt(2, 3);
            Assert.That(first.Floor().ToString() == "2" && second.Floor().ToString() == "0");
        }

        [Test]
        public void IsCeilCorrect()
        {
            var first = new Core.LargeInt(5, 2);
            var second = new Core.LargeInt(2, 3);
            Assert.That(first.Ceil().ToString() == "3" && second.Ceil().ToString() == "1");
        }

        [Test]
        public void IsRoundCorrect()
        {
            var first = new Core.LargeInt(5, 2);
            var second = new Core.LargeInt(2, 3);
            
            TestContext.Out.WriteLine(first.Round().ToString());
            TestContext.Out.WriteLine(second.Round().ToString());
            
            Assert.That(first.Round().ToString() == "3" && second.Round().ToString() == "1");
        }
    }
}