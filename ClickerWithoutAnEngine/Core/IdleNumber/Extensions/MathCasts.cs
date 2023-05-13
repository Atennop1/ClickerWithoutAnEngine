using System.Numerics;

namespace ClickerWithoutAnEngine.Core
{
    public static class MathCasts
    {
        public static int ToInt(this LargeInt value)
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
        
        public static IIdleNumber ToLargeInt(this byte value) 
            => new LargeInt((uint)value);

        public static IIdleNumber ToLargeInt(this sbyte value) 
            => new LargeInt(value);

        public static IIdleNumber ToLargeInt(this short value) 
            => new LargeInt(value);

        public static IIdleNumber ToLargeInt(this ushort value) 
            => new LargeInt((uint)value);

        public static IIdleNumber ToLargeInt(this int value) 
            => new LargeInt(value);

        public static IIdleNumber ToLargeInt(this long value) 
            => new LargeInt(value);

        public static IIdleNumber ToLargeInt(this uint value) 
            => new LargeInt(value);

        public static IIdleNumber ToLargeInt(this ulong value) 
            => new LargeInt(value);

        public static IIdleNumber ToLargeInt(this BigInteger value) 
            => new LargeInt(value);
    }
}