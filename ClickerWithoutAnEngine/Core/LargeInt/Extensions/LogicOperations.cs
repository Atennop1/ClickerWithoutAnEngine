namespace ClickerWithoutAnEngine.Core
{
    public static class LogicOperations
    {
        public static bool Equals(this ILargeInt left, ILargeInt right)
            => left.CompareTo(right) == 0;
        
        public static bool Less(this ILargeInt left, ILargeInt right) 
            => left.CompareTo(right) < 0;

        public static bool LessOrEquals(this ILargeInt left, ILargeInt right) 
            => left.CompareTo(right) <= 0;

        public static bool Greater(this ILargeInt left, ILargeInt right) 
            => left.CompareTo(right) > 0;

        public static bool GreaterOrEquals(this ILargeInt left, ILargeInt right) 
            => left.CompareTo(right) >= 0;

        public static bool ToBool(this ILargeInt value) 
            => !value.Equals(new LargeInt(0));
    }
}