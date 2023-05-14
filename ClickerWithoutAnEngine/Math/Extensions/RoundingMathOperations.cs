namespace ClickerWithoutAnEngine.Math
{
    public static class RoundingMathOperations
    {
        public static IIdleNumber Floor(this IIdleNumber value)
        {
            var decimalPlaces = System.Math.Max(-value.Exponent, 0);
            var expandedNumber = value.Number;

            for (var i = 0; i < decimalPlaces; i++) 
                expandedNumber *= 10f;

            var roundedNumber = (int)System.Math.Floor(expandedNumber);

            for (var i = 0; i < decimalPlaces; i++) 
                roundedNumber /= 10;

            return new IdleNumber(roundedNumber, value.Exponent);
        }
        
        public static IIdleNumber Ceil(this IIdleNumber value)
        {
            var decimalPlaces = System.Math.Max(-value.Exponent, 0);
            var expandedNumber = value.Number;

            for (var i = 0; i < decimalPlaces; i++) 
                expandedNumber *= 10f;

            var roundedNumber = (int)System.Math.Ceiling(expandedNumber);

            for (var i = 0; i < decimalPlaces; i++) 
                roundedNumber /= 10;

            return new IdleNumber(roundedNumber, value.Exponent);
        }
        
        public static IIdleNumber Round(this IIdleNumber value)
        {
            var roundedNumber = value;

            if (value.Exponent >= 0 || value.Number == System.Math.Floor(value.Number)) 
                return roundedNumber;
            
            var roundedDown = value.Floor();
            var roundedUp = value.Ceil();
                
            var diffDown = value.Number - roundedDown.Number;
            var diffUp = roundedUp.Number - value.Number;

            roundedNumber = diffDown < diffUp ? roundedDown : roundedUp;
            return roundedNumber;
        }
    }
}