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
            var integerString = "193748376483748374873847384783403099389489374364736847384637.38473784637856486364863468364";
            var largeInt = new Core.LargeInt(integerString);

            Assert.That(() => largeInt.Numerator == new Core.LargeInt("4843709412093709371846184619585077484737234359118421184615934618446159464121591215867091").Numerator && 
                              largeInt.Denominator == new Core.LargeInt("25000000000000000000000000000").Numerator);
        }
    }
}