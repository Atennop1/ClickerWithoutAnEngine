namespace ClickerWithoutAnEngine.Core
{
    public static class MathCasts
    {
        public static int ToInt(this IIdleNumber value)
        {
            if (value.Less(int.MinValue))
                throw new OverflowException("Value is less than System.int.MinValue.");
            
            if (value.Greater(int.MaxValue))
                throw new OverflowException("Value is greater than System.int.MaxValue.");

            return (int)(value.Number * 10.Pow(value.Exponent));
        }

        public static float ToFloat(this IIdleNumber value)
        {
            if (value.Less(float.MinValue))
                throw new OverflowException("Value is less than System.uint.MinValue.");
            
            if (value.Greater(float.MaxValue))
                throw new OverflowException("Value is greater than System.uint.MaxValue.");

            return value.Number * 10.Pow(value.Exponent);
        }
        
        public static IIdleNumber ToIdleNumber(this byte value) 
            => new IdleNumber(value);

        public static IIdleNumber ToIdleNumber(this sbyte value) 
            => new IdleNumber(value);

        public static IIdleNumber ToIdleNumber(this short value) 
            => new IdleNumber(value);

        public static IIdleNumber ToIdleNumber(this ushort value) 
            => new IdleNumber((uint)value);

        public static IIdleNumber ToIdleNumber(this int value) 
            => new IdleNumber(value);

        public static IIdleNumber ToIdleNumber(this long value) 
            => new IdleNumber(value);

        public static IIdleNumber ToIdleNumber(this uint value) 
            => new IdleNumber(value);

        public static IIdleNumber ToIdleNumber(this ulong value) 
            => new IdleNumber(value);
    }
}