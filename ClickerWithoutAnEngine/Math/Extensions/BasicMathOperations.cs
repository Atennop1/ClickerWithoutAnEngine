using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.Math
{
    public static class BasicMathOperations
    {
        public const int UsingDigitsCount = 9;
        
        public static IIdleNumber Add(this IIdleNumber idleNumber, int number)
            => idleNumber.Add(new IdleNumber(number));

        public static IIdleNumber Add(this IIdleNumber idleNumber, float number)
            => idleNumber.Add(new IdleNumber(number));

        public static IIdleNumber Add(this IIdleNumber first, IIdleNumber second)
        {
            if (first.Exponent == second.Exponent)
                return new IdleNumber(first.Number + second.Number, first.Exponent);

            var (higher, lower) = first.Exponent > second.Exponent ? (first, second) : (second, first);

            if (System.Math.Abs(higher.Exponent - lower.Exponent) > UsingDigitsCount)
                return higher;

            var newLowerNumber = lower.Number / 10.Pow(higher.Exponent - lower.Exponent);
            var newNumber = higher.Number + newLowerNumber;
            return new IdleNumber(newNumber, higher.Exponent);
        }

        
        
        public static IIdleNumber Subtract(this IIdleNumber idleNumber, int number)
            => idleNumber.Subtract(new IdleNumber(number));

        public static IIdleNumber Subtract(this IIdleNumber idleNumber, float number)
            => idleNumber.Subtract(new IdleNumber(number));

        public static IIdleNumber Subtract(this IIdleNumber first, IIdleNumber second)
        {
            if (first.Exponent == second.Exponent)
                return new IdleNumber(first.Number - second.Number, first.Exponent);

            if (first.Exponent > second.Exponent)
            {
                return first.Exponent - second.Exponent > UsingDigitsCount 
                    ? first : new IdleNumber(first.Number - second.Number / 10.Pow(first.Exponent - second.Exponent), first.Exponent);
            }
            
            return second.Exponent - first.Exponent > UsingDigitsCount 
                ? second.Negate()
                : new IdleNumber(first.Number / 10.Pow(second.Exponent - first.Exponent) - second.Number, second.Exponent);
        }

        
        
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
        {
            if (second.Number == 0)
                throw new DivideByZeroException();
            
            return new IdleNumber(first.Number / second.Number, first.Exponent - second.Exponent);
        }


        public static IIdleNumber Remainder(this IIdleNumber first, int second)
            => first.Remainder(new IdleNumber(second));
        
        public static IIdleNumber Remainder(this IIdleNumber first, float second)
            => first.Remainder(new IdleNumber(second));

        public static IIdleNumber Remainder(this IIdleNumber first, IIdleNumber second)
        {
            if (second.Number == 0f)
                throw new DivideByZeroException("Attempted to divide by zero.");

            if (first.Number == 0f || first.Exponent - second.Exponent < 0)
                return new IdleNumber();

            var exponentDifference = first.Exponent - second.Exponent;

            switch (exponentDifference)
            {
                case 0: return new IdleNumber(first.Number % second.Number, first.Exponent - second.Exponent);
                case > UsingDigitsCount: return new IdleNumber();
            }

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