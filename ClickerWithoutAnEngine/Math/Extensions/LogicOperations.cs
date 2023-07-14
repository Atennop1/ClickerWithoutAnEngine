namespace ClickerWithoutAnEngine.Math
{
    public static class LogicOperations
    {
        public static bool IsEquals(this IExponentialNumber left, int right)
            => left.IsEquals(new ExponentialNumber(right));

        public static bool IsEquals(this IExponentialNumber left, float right)
            => left.IsEquals(new ExponentialNumber(right));

        public static bool IsEquals(this IExponentialNumber left, IExponentialNumber right)
            => left.Exponent == right.Exponent && System.Math.Abs(left.Number - right.Number) < float.Epsilon;



        public static bool Less(this IExponentialNumber left, int right)
            => left.Less(new ExponentialNumber(right));

        public static bool Less(this IExponentialNumber left, float right)
            => left.Less(new ExponentialNumber(right));

        public static bool Less(this IExponentialNumber left, IExponentialNumber right)
        {
            if (left.Exponent == right.Exponent)
                return left.Number < right.Number;

            if (left.Exponent > right.Exponent)
                return left.Number < 0;

            return right.Number >= 0;
        }



        public static bool LessOrEquals(this IExponentialNumber left, int right)
            => left.LessOrEquals(new ExponentialNumber(right));

        public static bool LessOrEquals(this IExponentialNumber left, float right)
            => left.LessOrEquals(new ExponentialNumber(right));

        public static bool LessOrEquals(this IExponentialNumber left, IExponentialNumber right)
            => left.Less(right) || left.IsEquals(right);



        public static bool Greater(this IExponentialNumber left, int right)
            => left.Greater(new ExponentialNumber(right));

        public static bool Greater(this IExponentialNumber left, float right)
            => left.Greater(new ExponentialNumber(right));

        public static bool Greater(this IExponentialNumber left, IExponentialNumber right)
        {
            if (left.Exponent == right.Exponent)
                return left.Number > right.Number;

            if (left.Exponent > right.Exponent)
                return left.Number >= 0;

            return right.Number < 0;
        }



        public static bool GreaterOrEquals(this IExponentialNumber left, int right)
            => left.GreaterOrEquals(new ExponentialNumber(right));

        public static bool GreaterOrEquals(this IExponentialNumber left, float right)
            => left.GreaterOrEquals(new ExponentialNumber(right));

        public static bool GreaterOrEquals(this IExponentialNumber left, IExponentialNumber right)
            => left.Greater(right) || left.IsEquals(right);



        public static bool ToBool(this IExponentialNumber value)
            => !value.IsEquals(0);
    }
}