using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.Math
{
    public static class BasicMathOperations
    {
        public static IExponentialNumber Add(this IExponentialNumber exponentialNumber, int number)
            => exponentialNumber.Add(new ExponentialNumber(number));

        public static IExponentialNumber Add(this IExponentialNumber exponentialNumber, float number)
            => exponentialNumber.Add(new ExponentialNumber(number));

        public static IExponentialNumber Add(this IExponentialNumber first, IExponentialNumber second)
        {
            if (first.Exponent == second.Exponent)
                return new ExponentialNumber(first.Number + second.Number, first.Exponent);

            var (higher, lower) = first.Exponent > second.Exponent ? (first, second) : (second, first);

            if (System.Math.Abs(higher.Exponent - lower.Exponent) > Constants.UsingDigitsCount)
                return higher;

            var newLowerNumber = lower.Number / 10.Pow(higher.Exponent - lower.Exponent);
            var newNumber = higher.Number + newLowerNumber;
            return new ExponentialNumber(newNumber, higher.Exponent);
        }

        
        
        public static IExponentialNumber Subtract(this IExponentialNumber exponentialNumber, int number)
            => exponentialNumber.Subtract(new ExponentialNumber(number));

        public static IExponentialNumber Subtract(this IExponentialNumber exponentialNumber, float number)
            => exponentialNumber.Subtract(new ExponentialNumber(number));

        public static IExponentialNumber Subtract(this IExponentialNumber first, IExponentialNumber second)
        {
            if (first.Exponent == second.Exponent)
                return new ExponentialNumber(first.Number - second.Number, first.Exponent);

            if (first.Exponent > second.Exponent)
            {
                return first.Exponent - second.Exponent > Constants.UsingDigitsCount 
                    ? first : new ExponentialNumber(first.Number - second.Number / 10.Pow(first.Exponent - second.Exponent), first.Exponent);
            }
            
            return second.Exponent - first.Exponent > Constants.UsingDigitsCount 
                ? second.Negate()
                : new ExponentialNumber(first.Number / 10.Pow(second.Exponent - first.Exponent) - second.Number, second.Exponent);
        }

        
        
        public static IExponentialNumber Multiply(this IExponentialNumber exponentialNumber, int number)
            => exponentialNumber.Multiply(new ExponentialNumber(number));

        public static IExponentialNumber Multiply(this IExponentialNumber exponentialNumber, float number)
            => exponentialNumber.Multiply(new ExponentialNumber(number));
        
        public static IExponentialNumber Multiply(this IExponentialNumber first, IExponentialNumber second) 
            => new ExponentialNumber(first.Number * second.Number, first.Exponent + second.Exponent);


        public static IExponentialNumber Divide(this IExponentialNumber exponentialNumber, int number)
            => exponentialNumber.Divide(new ExponentialNumber(number));
        
        public static IExponentialNumber Divide(this IExponentialNumber exponentialNumber, float number)
            => exponentialNumber.Divide(new ExponentialNumber(number));
        
        public static IExponentialNumber Divide(this IExponentialNumber first, IExponentialNumber second)
        {
            if (second.Number == 0)
                throw new DivideByZeroException();
            
            return new ExponentialNumber(first.Number / second.Number, first.Exponent - second.Exponent);
        }


        public static IExponentialNumber Remainder(this IExponentialNumber first, int second)
            => first.Remainder(new ExponentialNumber(second));
        
        public static IExponentialNumber Remainder(this IExponentialNumber first, float second)
            => first.Remainder(new ExponentialNumber(second));

        public static IExponentialNumber Remainder(this IExponentialNumber first, IExponentialNumber second)
        {
            if (second.Number == 0f)
                throw new DivideByZeroException("Attempted to divide by zero.");

            if (first.Number == 0f || first.Exponent - second.Exponent < 0)
                return new ExponentialNumber();

            var exponentDifference = first.Exponent - second.Exponent;

            switch (exponentDifference)
            {
                case 0: return new ExponentialNumber(first.Number % second.Number, first.Exponent - second.Exponent);
                case > Constants.UsingDigitsCount: return new ExponentialNumber(second.Number - 1, second.Exponent);
            }

            var adjustedDivisor = second.Number * 10.Pow(exponentDifference);
            var remainder = first.Number % adjustedDivisor;
            return new ExponentialNumber(remainder, first.Exponent);
        }

        
        
        public static IExponentialNumber Pow(this IExponentialNumber exponentialNumber, int power)
        {
            if (power == 0)
                return new ExponentialNumber(1f);

            if (exponentialNumber.Number == 0f)
                return new ExponentialNumber();

            var newExponent = exponentialNumber.Exponent * power;
            var newNumber = System.Math.Pow(exponentialNumber.Number, power);

            return new ExponentialNumber(newNumber, newExponent);
        }
    }
}