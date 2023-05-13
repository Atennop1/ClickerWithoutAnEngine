using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class RoundingMathOperations
    {
        public static IIdleNumber Floor(this IIdleNumber value)
        {
            var numerator = value.Numerator - BigInteger.Remainder(value.Numerator, value.Denominator);
            
            if (numerator < 0)
                numerator += value.Denominator;

            var result = new LargeInt(numerator, value.Denominator);
            return result.Simplify();
        }
        
        public static IIdleNumber Ceil(this IIdleNumber value)
        {
            var numerator = value.Numerator - BigInteger.Remainder(value.Numerator, value.Denominator);
            
            if (value.Numerator >= 0)
                numerator += value.Denominator;

            var result = new LargeInt(numerator, value.Denominator);
            return result.Simplify();
        }
        
        public static IIdleNumber Round(this IIdleNumber value) 
        {
            var result = new LargeInt(BigInteger.Remainder(value.Numerator, value.Denominator), value.Denominator);
            return result.CompareTo(new LargeInt(new BigInteger(0.5))) >= 0 ? value.Ceil() : value.Floor();
        }
    }
}