using ClickerWithoutAnEngine.Core;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class BasicMathOperationsTest
    {
        [Test]
        public void IsAddingCorrect()
        {
            var first = new Core.LargeInt(10, 5);
            var second = new Core.LargeInt(10, 2);
            Assert.That(first.Add(second).ToString() == "7");
        }

        [Test]
        public void IsSubtractingCorrect()
        {
            var first = new Core.LargeInt(10, 5);
            var second = new Core.LargeInt(10, 2);
            Assert.That(first.Subtract(second).ToString() == "-3");
        }

        [Test]
        public void IsMultiplyingCorrect()
        {
            var first = new Core.LargeInt(10, 5);
            var second = new Core.LargeInt(10, 2);
            Assert.That(first.Multiply(second).ToString() == "10");
        }

        [Test]
        public void IsDividingCorrect()
        {
            var first = new Core.LargeInt(10, 5);
            var second = new Core.LargeInt(10, 2);
            Assert.That(first.Divide(second).ToString() == "0.4");
        }

        [Test]
        public void IsPowCorrect()
        {
            var largeInt = new Core.LargeInt(10, 5);
            var result = largeInt.Pow(2);
            Assert.That(result.Numerator == 100 && result.Denominator == 25 && result.ToString() == "4");
        }

        [Test]
        public void IsIncrementCorrect()
        {
            var largeInt = new Core.LargeInt(10, 5);
            var result = largeInt.Increment();
            Assert.That(result.Numerator == 15 && result.Denominator == 5 && result.ToString() == "3");
        }

        [Test]
        public void IsDecrementCorrect()
        {
            var largeInt = new Core.LargeInt(10, 5);
            var result = largeInt.Decrement();
            Assert.That(result.Numerator == 5 && result.Denominator == 5 && result.ToString() == "1");
        }
    }
}