using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.Math
{
    public static class SpecificMathOperations
    {
        public static IIdleNumber Abs(this IIdleNumber value)
            => new IdleNumber(System.Math.Abs(value.Number), value.Exponent);

        public static IIdleNumber Negate(this IIdleNumber value)
            => new IdleNumber(-value.Number, value.Exponent);

        public static IIdleNumber Inverse(this IIdleNumber value) 
            => value.Number == 0 ? value : new IdleNumber(1).Divide(value);

        public static IIdleNumber ShiftLeft(this IIdleNumber value, int shift) 
            => shift < 0 ? value.ShiftRight(-shift) : value.Multiply(10.Pow(shift));

        public static IIdleNumber ShiftRight(this IIdleNumber value, int shift) 
            => shift < 0 ? value.ShiftLeft(-shift) : value.Divide(10.Pow(shift));
    }
}