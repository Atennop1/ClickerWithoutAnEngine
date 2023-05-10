using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class BasicMathOperations
    {
        public static ILargeInt Increment(this ILargeInt largeInt) 
            => new LargeInt(largeInt.Numerator + largeInt.Denominator, largeInt.Denominator);

        public static ILargeInt Decrement(this ILargeInt largeInt)
            => new LargeInt(largeInt.Numerator - largeInt.Denominator, largeInt.Denominator);
        
        public static ILargeInt Add(this ILargeInt first, ILargeInt second)
        {
            if (Equals(second, null))
                throw new ArgumentNullException(nameof(second));

            var numerator = first.Numerator * second.Denominator + second.Numerator * first.Denominator;
            var denominator = first.Denominator * second.Denominator;
            return new LargeInt(numerator, denominator);
        }

        public static ILargeInt Subtract(this ILargeInt first, ILargeInt second)
        {
            if (Equals(second, null))
                throw new ArgumentNullException(nameof(second));

            var numerator = first.Numerator * second.Denominator - second.Numerator * first.Denominator;
            var denominator = first.Denominator * second.Denominator;
            return new LargeInt(numerator, denominator);
        }

        public static ILargeInt Multiply(this ILargeInt first, ILargeInt second)
        {
            if (Equals(second, null))
                throw new ArgumentNullException(nameof(second));
            
            return new LargeInt(first.Numerator * second.Numerator, first.Denominator * second.Denominator);
        }

        public static ILargeInt Divide(this ILargeInt first, ILargeInt second)
        {
            if (Equals(second, null))
                throw new ArgumentNullException(nameof(second));

            if (second.Numerator == 0)
                throw new DivideByZeroException();
            
            return new LargeInt(first.Numerator * second.Denominator, first.Denominator * second.Numerator);
        }

        public static ILargeInt Remainder(this ILargeInt first, ILargeInt second)
        {
            if (Equals(second, null))
                throw new ArgumentNullException(nameof(second));

            var result = first.Subtract(first.Divide(second).Floor()).Multiply(second);
            return new LargeInt(result);
        }

        public static ILargeInt Pow(this ILargeInt largeInt, int exponent)
        {
            if (largeInt.Numerator.IsZero)
                return largeInt;

            BigInteger numerator;
            BigInteger denominator;
            
            if (exponent < 0)
            {
                var savedNumerator = largeInt.Numerator;
                numerator = BigInteger.Pow(largeInt.Denominator, -exponent);
                denominator = BigInteger.Pow(savedNumerator, -exponent);
            }
            else
            {
                numerator = BigInteger.Pow(largeInt.Numerator, exponent);
                denominator = BigInteger.Pow(largeInt.Denominator, exponent);
            }

            return new LargeInt(numerator, denominator);
        }
    }
}