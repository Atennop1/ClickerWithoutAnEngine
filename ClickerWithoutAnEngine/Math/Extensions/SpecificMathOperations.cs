namespace ClickerWithoutAnEngine.Math
{
    public static class SpecificMathOperations
    {
        public static IExponentialNumber Abs(this IExponentialNumber value)
            => new ExponentialNumber(System.Math.Abs(value.Number), value.Exponent);

        public static IExponentialNumber Negate(this IExponentialNumber value)
            => new ExponentialNumber(-value.Number, value.Exponent);

        public static IExponentialNumber Inverse(this IExponentialNumber value) 
            => value.Number == 0 ? value : new ExponentialNumber(1).Divide(value);

        public static IExponentialNumber ShiftLeft(this IExponentialNumber value, int shift) 
            => shift < 0 ? value.ShiftRight(-shift) : value.Multiply(new ExponentialNumber(1, shift));

        public static IExponentialNumber ShiftRight(this IExponentialNumber value, int shift) 
            => shift < 0 ? value.ShiftLeft(-shift) : value.Divide(new ExponentialNumber(1, shift));
    }
}