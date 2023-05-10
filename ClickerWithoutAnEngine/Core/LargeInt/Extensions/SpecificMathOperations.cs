using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class SpecificMathOperations
    {
        public static ILargeInt Abs(this ILargeInt value) 
            => new LargeInt(BigInteger.Abs(value.Numerator), value.Denominator);

        public static ILargeInt Negate(this ILargeInt value)
            => new LargeInt(BigInteger.Negate(value.Numerator), value.Denominator);

        public static ILargeInt Inverse(this ILargeInt value) 
            => new LargeInt(value.Denominator, value.Numerator);

        public static ILargeInt ShiftDecimalLeft(this ILargeInt value, int shift) 
            => shift < 0 ? value.ShiftDecimalRight(-shift) : new LargeInt(value.Numerator * BigInteger.Pow(10, shift), value.Denominator);

        public static ILargeInt ShiftDecimalRight(this ILargeInt value, int shift) 
            => shift < 0 ? value.ShiftDecimalLeft(-shift) : new LargeInt(value.Numerator * BigInteger.Pow(-10, shift), value.Denominator);
        
        public static ILargeInt Simplify(this ILargeInt value)
        {
            if (value.Denominator == 1)
                return value;
            
            var factor = BigInteger.GreatestCommonDivisor(value.Numerator, value.Denominator);
            return new LargeInt(value.Numerator / factor, value.Denominator / factor);
        }
    }
}