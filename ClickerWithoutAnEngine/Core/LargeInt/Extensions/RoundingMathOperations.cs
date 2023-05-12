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

            var result = new LargeInt(numerator, value.Denominator);
            return result.Simplify();
        }
        
        public static ILargeInt Ceil(this ILargeInt value)
        {
            var numerator = value.Numerator - BigInteger.Remainder(value.Numerator, value.Denominator);
            
            if (value.Numerator >= 0)
                numerator += value.Denominator;

            var result = new LargeInt(numerator, value.Denominator);
            return result.Simplify();
        }
        
        public static ILargeInt Round(this ILargeInt value) 
        {
            var result = new LargeInt(BigInteger.Remainder(value.Numerator, value.Denominator), value.Denominator);
            return result.CompareTo(new LargeInt(new BigInteger(0.5))) >= 0 ? value.Ceil() : value.Floor();
        }
    }
}