namespace ClickerWithoutAnEngine.Math
{
    public static class LogicOperations
    {
        public static bool IsEquals(this IIdleNumber left, int right)
            => left.IsEquals(new IdleNumber(right));

        public static bool IsEquals(this IIdleNumber left, float right)
            => left.IsEquals(new IdleNumber(right));

        public static bool IsEquals(this IIdleNumber left, IIdleNumber right)
            => left.Exponent == right.Exponent && System.Math.Abs(left.Number - right.Number) < float.Epsilon;



        public static bool Less(this IIdleNumber left, int right)
            => left.Less(new IdleNumber(right));

        public static bool Less(this IIdleNumber left, float right)
            => left.Less(new IdleNumber(right));

        public static bool Less(this IIdleNumber left, IIdleNumber right)
        {
            if (left.Exponent == right.Exponent)
            {
                if (left.Number < 0 || right.Number < 0)
                    return left.Number > right.Number;

                return left.Number < right.Number;
            }

            if (left.Exponent < right.Exponent)
                return left.Number >= 0 && right.Number >= 0;

            return left.Number < 0 || right.Number < 0;
        }



        public static bool LessOrEquals(this IIdleNumber left, int right)
            => left.LessOrEquals(new IdleNumber(right));

        public static bool LessOrEquals(this IIdleNumber left, float right)
            => left.LessOrEquals(new IdleNumber(right));

        public static bool LessOrEquals(this IIdleNumber left, IIdleNumber right)
            => left.Less(right) || left.IsEquals(right);



        public static bool Greater(this IIdleNumber left, int right)
            => left.Greater(new IdleNumber(right));

        public static bool Greater(this IIdleNumber left, float right)
            => left.Greater(new IdleNumber(right));

        public static bool Greater(this IIdleNumber left, IIdleNumber right)
        {
            if (left.Exponent > right.Exponent)
            {
                if (left.Number < 0 && right.Number < 0)
                    return left.Number > right.Number;
                
                return true;
            }

            if (left.Exponent >= right.Exponent) 
                return left.Number > right.Number;
            
            if (left.Number < 0 && right.Number < 0)
                return left.Number > right.Number;
                
            return false;
        }



        public static bool GreaterOrEquals(this IIdleNumber left, int right)
            => left.GreaterOrEquals(new IdleNumber(right));

        public static bool GreaterOrEquals(this IIdleNumber left, float right)
            => left.GreaterOrEquals(new IdleNumber(right));

        public static bool GreaterOrEquals(this IIdleNumber left, IIdleNumber right)
            => left.Greater(right) || left.IsEquals(right);



        public static bool ToBool(this IIdleNumber value)
            => !value.IsEquals(0);
    }
}