namespace ClickerWithoutAnEngine.Tools
{
    public static class FloatExtensions
    {
        public static int Sign(this float value) 
            => value >= 0 ? 1 : -1;
        
        public static float ThrowExceptionIfLessThanZero(this float number)
        {
            if (number < 0)
                throw new ArgumentException("Number can't be less than zero");

            return number;
        }

        public static float ThrowExceptionIfLessOrEqualsZero(this float number)
        {
            if (number == 0)
                throw new ArgumentException("Number can't be zero");

            return number.ThrowExceptionIfLessThanZero();
        }
    }
}