using ClickerWithoutAnEngine.Extensions;

namespace ClickerWithoutAnEngine.Math
{
    public static class SpecificMathOperations
    {
        public static IIdleNumber Abs(this IIdleNumber value)
            => new IdleNumber(System.Math.Abs(value.Number), value.Exponent);

        public static IIdleNumber Negate(this IIdleNumber value)
            => new IdleNumber(-value.Number, value.Exponent);

        public static IIdleNumber Inverse(this IIdleNumber value)
            => new IdleNumber(1).Divide(value);

        public static IIdleNumber ShiftDecimalLeft(this IIdleNumber value, int shift) 
            => shift < 0 ? value.ShiftDecimalRight(-shift) : value.Multiply(10.Pow(shift));

        public static IIdleNumber ShiftDecimalRight(this IIdleNumber value, int shift) 
            => shift < 0 ? value.ShiftDecimalLeft(-shift) : value.Divide(10.Pow(shift));
    }
}