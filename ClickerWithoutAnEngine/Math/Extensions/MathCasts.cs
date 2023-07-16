using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.Math
{
    public static class MathCasts
    {
        public static int ToInt(this IExponentialNumber value)
        {
            if (value.Less(int.MinValue))
                throw new OverflowException("Value is less than System.int.MinValue.");
            
            if (value.Greater(int.MaxValue))
                throw new OverflowException("Value is greater than System.int.MaxValue.");

            return (int)(value.Number * 10.Pow(value.Exponent));
        }

        public static double ToDouble(this IExponentialNumber value)
        {
            if (value.Less(double.MinValue))
                throw new OverflowException("Value is less than System.double.MinValue.");
            
            if (value.Greater(double.MaxValue))
                throw new OverflowException("Value is greater than System.double.MaxValue.");

            return (float)value.Number * 10.Pow(value.Exponent);
        }
        
        public static IExponentialNumber ToIdleNumber(this byte value) 
            => new ExponentialNumber(value);

        public static IExponentialNumber ToIdleNumber(this sbyte value) 
            => new ExponentialNumber(value);

        public static IExponentialNumber ToIdleNumber(this short value) 
            => new ExponentialNumber(value);

        public static IExponentialNumber ToIdleNumber(this ushort value) 
            => new ExponentialNumber(value);

        public static IExponentialNumber ToIdleNumber(this int value) 
            => new ExponentialNumber(value);
        
        public static IExponentialNumber ToIdleNumber(this uint value) 
            => new ExponentialNumber(value);

        public static IExponentialNumber ToIdleNumber(this long value) 
            => new ExponentialNumber(value);

        public static IExponentialNumber ToIdleNumber(this ulong value) 
            => new ExponentialNumber(value);
        
        public static IExponentialNumber ToIdleNumber(this float value) 
            => new ExponentialNumber(value);
        
        public static IExponentialNumber ToIdleNumber(this double value) 
            => new ExponentialNumber(value);
    }
}