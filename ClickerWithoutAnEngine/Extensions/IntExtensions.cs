namespace ClickerWithoutAnEngine.Extensions
{
    public static class IntExtensions
    {
        public static float Pow(this int value, int exponent)
        {
            var result = 1;
            
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                    result *= value;
                
                value *= value;
                exponent >>= 1;
            }
            
            return result;
        }
        
        public static int ThrowExceptionIfLessThanZero(this int number)
        {
            if (number < 0)
                throw new ArgumentException("Number can't be less than zero");

            return number;
        }

        public static int ThrowExceptionIfLessOrEqualsZero(this int number)
        {
            if (number == 0)
                throw new ArgumentException("Number can't be zero");

            return number.ThrowExceptionIfLessThanZero();
        }
    }
}