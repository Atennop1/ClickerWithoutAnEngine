using ClickerWithoutAnEngine.Extensions;

namespace ClickerWithoutAnEngine.Math
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
            => idleNumber.Multiply(new IdleNumber(number));

        public static IIdleNumber Multiply(this IIdleNumber idleNumber, float number)
            => idleNumber.Multiply(new IdleNumber(number));
        
        public static IIdleNumber Multiply(this IIdleNumber first, IIdleNumber second) 
            => new IdleNumber(first.Number * second.Number, first.Exponent + second.Exponent);


        public static IIdleNumber Divide(this IIdleNumber idleNumber, int number)
            => idleNumber.Divide(new IdleNumber(number));
        
        public static IIdleNumber Divide(this IIdleNumber idleNumber, float number)
            => idleNumber.Divide(new IdleNumber(number));
        
        public static IIdleNumber Divide(this IIdleNumber first, IIdleNumber second) 
            => new IdleNumber(first.Number / second.Number, first.Exponent - second.Exponent);


        public static IIdleNumber Remainder(this IIdleNumber first, int second)
            => first.Divide(new IdleNumber(second));
        
        public static IIdleNumber Remainder(this IIdleNumber first, float second)
            => first.Divide(new IdleNumber(second));

        public static IIdleNumber Remainder(this IIdleNumber first, IIdleNumber second)
        {
            if (second.Number == 0f)
                throw new DivideByZeroException("Attempted to divide by zero.");

            if (first.Number == 0f)
                return new IdleNumber();

            var exponentDifference = first.Exponent - second.Exponent;
            var adjustedDivisor = second.Number * 10.Pow(exponentDifference);

            var remainder = first.Number % adjustedDivisor;
            return new IdleNumber(remainder, first.Exponent);
        }

        
        
        public static IIdleNumber Pow(this IIdleNumber idleNumber, int power)
        {
            if (power == 0)
                return new IdleNumber(1f);

            if (idleNumber.Number == 0f)
                return new IdleNumber();

            var newExponent = idleNumber.Exponent * power;
            var newNumber = (float)System.Math.Pow(idleNumber.Number, power);

            return new IdleNumber(newNumber, newExponent);
        }
    }
}