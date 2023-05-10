using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class RoundingMathOperations
    {
        public static ILargeInt Floor(this ILargeInt value)
        {
            var numerator = value.Numerator - BigInteger.Remainder(value.Numerator, value.Denominator);
            
            if (numerator < 0)
                numerator += value.Denominator;

            value.Simplify();
            return new LargeInt(numerator, value.Denominator);
        }
    }
}