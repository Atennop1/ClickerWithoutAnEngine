using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class SpecificMathOperations
    {
        public static IIdleNumber Abs(this IIdleNumber value) 
            => new LargeInt(BigInteger.Abs(value.Numerator), BigInteger.Abs(value.Denominator));

        public static IIdleNumber Negate(this IIdleNumber value)
            => new LargeInt(BigInteger.Negate(value.Numerator), value.Denominator);

        public static IIdleNumber Inverse(this IIdleNumber value) 
            => new LargeInt(value.Denominator, value.Numerator);

        public static IIdleNumber ShiftDecimalLeft(this IIdleNumber value, int shift) 
            => shift < 0 ? value.ShiftDecimalRight(-shift) : new LargeInt(value.Numerator * BigInteger.Pow(10, shift), value.Denominator);

        public static IIdleNumber ShiftDecimalRight(this IIdleNumber value, int shift) 
            => shift < 0 ? value.ShiftDecimalLeft(-shift) : new LargeInt(value.Numerator, value.Denominator * BigInteger.Pow(10, shift));
        
        public static IIdleNumber Simplify(this IIdleNumber value)
        {
            if (value.Denominator == 1)
                return value;
            
            var factor = BigInteger.GreatestCommonDivisor(value.Numerator, value.Denominator);
            return new LargeInt(value.Numerator / factor, value.Denominator / factor);
        }
    }
}