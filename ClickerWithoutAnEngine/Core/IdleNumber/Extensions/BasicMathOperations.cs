using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class BasicMathOperations
    {
        public static IIdleNumber Add(this IIdleNumber idleNumber, int number)
            => new IdleNumber(idleNumber.Number + number / 10.Pow(idleNumber.Exponent), idleNumber.Exponent);
        
        public static IIdleNumber Add(this IIdleNumber idleNumber, float number)
            => new IdleNumber(idleNumber.Number + number / 10.Pow(idleNumber.Exponent), idleNumber.Exponent);
        
        public static IIdleNumber Add(this IIdleNumber first, IIdleNumber second) 
            => first.Exponent >= second.Exponent 
               ? first.Add(second.Number / 10.Pow(first.Exponent - second.Exponent)) 
               : second.Add(first.Number / 10.Pow(second.Exponent - first.Exponent));

        
        
        public static IIdleNumber Subtract(this IIdleNumber idleNumber, int number)
            => new IdleNumber(idleNumber.Number - number / 10.Pow(idleNumber.Exponent), idleNumber.Exponent);
        
        public static IIdleNumber Subtract(this IIdleNumber idleNumber, float number)
            => new IdleNumber(idleNumber.Number - number / 10.Pow(idleNumber.Exponent), idleNumber.Exponent);
        
        public static IIdleNumber Subtract(this IIdleNumber first, IIdleNumber second) 
            => first.Exponent >= second.Exponent 
               ? first.Subtract(second.Number / 10.Pow(first.Exponent - second.Exponent)) 
               : second.Subtract(first.Number / 10.Pow(second.Exponent - first.Exponent));

        
        
        public static IIdleNumber Multiply(this IIdleNumber idleNumber, int number)
            => new IdleNumber(idleNumber.Number * number, idleNumber.Exponent);
        
        public static IIdleNumber Multiply(this IIdleNumber idleNumber, float number)
            => new IdleNumber(idleNumber.Number * number, idleNumber.Exponent);
        
        public static IIdleNumber Multiply(this IIdleNumber first, IIdleNumber second)
        {
            var result = first.Multiply(second.Number);
            return new IdleNumber(result.Number, result.Exponent + second.Exponent);
        }

        
        public static IIdleNumber Divide(this IIdleNumber idleNumber, int number)
            => new IdleNumber(idleNumber.Multiply(1f / number));
        
        public static IIdleNumber Divide(this IIdleNumber idleNumber, float number)
            => new IdleNumber(idleNumber.Multiply(1f / number));
        
        public static IIdleNumber Divide(this IIdleNumber first, IIdleNumber second)
        {
            var result = first.Divide(second.Number);
            return new IdleNumber(result.Number, result.Exponent - second.Exponent);
        }

        public static IIdleNumber Remainder(this IIdleNumber first, IIdleNumber second)
        {
            if (Equals(second, null))
                throw new ArgumentNullException(nameof(second));

            var result = first.Subtract(first.Divide(second).Floor().Multiply(second));
            return new LargeInt(result);
        }

        public static IIdleNumber Pow(this IIdleNumber largeInt, int exponent)
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