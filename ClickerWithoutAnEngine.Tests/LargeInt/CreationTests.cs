using System.Numerics;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.LargeInt
{
    public sealed class CreationTests
    {
        [Test]
        public void IsCreationByIntCorrect()
        {
            var integer = 10;
            var largeInt = new Core.LargeInt(integer);
            Assert.That(() => integer == largeInt.Numerator && largeInt.Denominator == 1);
        }
        
        [Test]
        public void IsCreationByUnsignedIntCorrect()
        {
            uint integer = 10;
            var largeInt = new Core.LargeInt(integer);
            Assert.That(() => integer == largeInt.Numerator && largeInt.Denominator == 1);
        }
        
        [Test]
        public void IsCreationByLongCorrect()
        {
            var longInteger = 10L;
            var largeInt = new Core.LargeInt(longInteger);
            Assert.That(() => longInteger == largeInt.Numerator && largeInt.Denominator == 1);
        }
        
        [Test]
        public void IsCreationByUnsignedLongCorrect()
        {
            var longInteger = 10L;
            var largeInt = new Core.LargeInt(longInteger);
            Assert.That(() => longInteger == largeInt.Numerator && largeInt.Denominator == 1);
        }

        [Test]
        public void IsCreationByBigIntegerCorrect()
        {
            var bigInteger = new BigInteger(10);
            var largeInt = new Core.LargeInt(bigInteger);
            Assert.That(() => bigInteger == largeInt.Numerator && largeInt.Denominator == 1);
        }

        [Test]
        public void IsCreationWithDenominatorCorrect()
        {
            var numerator = new BigInteger(20);
            var denominator = new BigInteger(10);

            var largeInt = new Core.LargeInt(numerator, denominator);
            Assert.That(() => largeInt.Numerator == numerator && largeInt.Denominator == denominator);
        }

        [Test]
        public void IsCreationByLargeIntCorrect()
        {
            var firstLargeInt = new Core.LargeInt(new BigInteger(20), new BigInteger(10));
            var secondLargeInt = new Core.LargeInt(firstLargeInt);
            Assert.That(() => firstLargeInt.Numerator == secondLargeInt.Numerator && firstLargeInt.Denominator == secondLargeInt.Denominator);
        }

        [Test]
        public void IsCreationByStringCorrect()
        {
            var integerString = "100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000.5";
            var largeInt = new Core.LargeInt(integerString);
            Assert.That(() => largeInt.Numerator == new Core.LargeInt("200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001").Numerator && largeInt.Denominator == 2);
        }
    }
}