namespace ClickerWithoutAnEngine.Core
{
    public static class LogicOperations
    {
        public static bool Less(this IIdleNumber left, IIdleNumber right) 
            => left.CompareTo(right) < 0;

        public static bool LessOrEquals(this IIdleNumber left, IIdleNumber right) 
            => left.CompareTo(right) <= 0;

        public static bool Greater(this IIdleNumber left, IIdleNumber right) 
            => left.CompareTo(right) > 0;

        public static bool GreaterOrEquals(this IIdleNumber left, IIdleNumber right) 
            => left.CompareTo(right) >= 0;

        public static bool ToBool(this IIdleNumber value) 
            => !value.Equals(new LargeInt(0));
    }
}