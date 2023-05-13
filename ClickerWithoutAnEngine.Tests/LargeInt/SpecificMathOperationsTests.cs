using ClickerWithoutAnEngine.Core;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class SpecificMathOperationsTests
    {
        [Test]
        public void IsAbsCorrect()
        {
            var first = new Core.LargeInt(-10, 2);
            var second = new Core.LargeInt(-10, -2);
            Assert.That(first.Abs().ToString() == "5" && second.Abs().ToString() == "5");
        }

        [Test]
        public void IsNegateCorrect()
        {
            var first = new Core.LargeInt(-10, 2);
            var second = new Core.LargeInt(-10, -2);
            Assert.That(first.Negate().ToString() == "5" && second.Negate().ToString() == "-5");
        }

        [Test]
        public void IsInverseCorrect()
        {
            var first = new Core.LargeInt(10, -2);
            var second = new Core.LargeInt(-10, -5);
            Assert.That(first.Inverse().ToString() == "-0.2" && second.Inverse().ToString() == "0.5");
        }

        [Test]
        public void IsShiftLeftCorrect()
        {
            var first = new Core.LargeInt(10, 100);
            var second = new Core.LargeInt(10, 1);
            Assert.That(first.ShiftDecimalLeft(2).ToString() == "10" && second.ShiftDecimalLeft(2).ToString() == "1000");
        }

        [Test]
        public void IsShiftRightCorrect()
        {
            var first = new Core.LargeInt(10, 100);
            var second = new Core.LargeInt(10, 1);
            Assert.That(first.ShiftDecimalRight(2).ToString() == "0.001" && second.ShiftDecimalRight(2).ToString() == "0.1");
        }

        [Test]
        public void IsSimplifyCorrect()
        {
            var first = new Core.LargeInt(10, -5);
            var second = new Core.LargeInt(-8, 4);
            Assert.That(first.ToString() == "-2" && second.ToString() == "-2");
        }

        [Test]
        public void IsToStringCorrect()
        {
            var first = new Core.LargeInt(10);
            var second = new Core.LargeInt(8, 5);
            
            var third = new Core.LargeInt(-10);
            var fourth = new Core.LargeInt(-8, 5);

            var fifth = new Core.LargeInt(1, 3);
            var sixth = new Core.LargeInt(-1, 3);

            Assert.That(first.ToString() == "10" && second.ToString() == "1.6" && third.ToString() == "-10" &&
                        fourth.ToString() == "-1.6" && fifth.ToString() == "0.333333333333" && sixth.ToString() == "-0.333333333333");
        }
    }
}