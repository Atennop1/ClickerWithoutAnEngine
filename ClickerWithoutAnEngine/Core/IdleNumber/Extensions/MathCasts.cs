using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class MathCasts
    {
        public static int ToInt(this IIdleNumber value)
        {
            if (value.Less(int.MinValue.ToLargeInt()))
                throw new OverflowException("Value is less than System.int.MinValue.");
            
            if (value.Greater(int.MaxValue.ToLargeInt()))
                throw new OverflowException("Value is greater than System.int.MaxValue.");

            return (int)value.Numerator / (int)value.Denominator;
        }

        public static uint ToUnsignedInt(this IIdleNumber value)
        {
            if (value.Less(uint.MinValue.ToLargeInt()))
                throw new OverflowException("Value is less than System.uint.MinValue.");
            
            if (value.Greater(uint.MaxValue.ToLargeInt()))
                throw new OverflowException("Value is greater than System.uint.MaxValue.");

            return (uint)value.Numerator / (uint)value.Denominator;
        }
        
        public static IIdleNumber ToIdleNumber(this byte value) 
            => new LargeInt((uint)value);

        public static IIdleNumber ToIdleNumber(this sbyte value) 
            => new LargeInt(value);

        public static IIdleNumber ToIdleNumber(this short value) 
            => new LargeInt(value);

        public static IIdleNumber ToIdleNumber(this ushort value) 
            => new LargeInt((uint)value);

        public static IIdleNumber ToIdleNumber(this int value) 
            => new LargeInt(value);

        public static IIdleNumber ToIdleNumber(this long value) 
            => new LargeInt(value);

        public static IIdleNumber ToIdleNumber(this uint value) 
            => new LargeInt(value);

        public static IIdleNumber ToIdleNumber(this ulong value) 
            => new LargeInt(value);

        public static IIdleNumber ToIdleNumber(this BigInteger value) 
            => new LargeInt(value);
    }
}