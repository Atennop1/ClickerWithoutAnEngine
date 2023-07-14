namespace ClickerWithoutAnEngine.Math
{
    public static class RoundingMathOperations
    {
        public static IExponentialNumber Floor(this IExponentialNumber value)
        {
            if (-value.Exponent > Constants.UsingDigitsCount)
                return new ExponentialNumber();

            var decimalPlaces = System.Math.Max(-value.Exponent, 0);
            var expandedNumber = value.Number;

            for (var i = 0; i < decimalPlaces; i++)
                expandedNumber *= 10f;

            var roundedNumber = (int)System.Math.Floor(expandedNumber);

            for (var i = 0; i < decimalPlaces; i++)
                roundedNumber /= 10;

            return new ExponentialNumber(roundedNumber, value.Exponent);
        }

        public static IExponentialNumber Ceil(this IExponentialNumber value)
        {
            if (-value.Exponent > Constants.UsingDigitsCount)
                return new ExponentialNumber();
            
            var decimalPlaces = System.Math.Max(-value.Exponent, 0);
            var expandedNumber = value.Number;

            for (var i = 0; i < decimalPlaces; i++)
                expandedNumber *= 10f;

            var roundedNumber = (int)System.Math.Ceiling(expandedNumber);

            for (var i = 0; i < decimalPlaces; i++)
                roundedNumber /= 10;

            return new ExponentialNumber(roundedNumber, value.Exponent);
        }

        public static IExponentialNumber Round(this IExponentialNumber value)
        {
            var floor = value.Floor();
            var ceil = value.Ceil();

            var diffFloor = System.Math.Abs(value.Number - floor.Number);
            var diffCeil = System.Math.Abs(ceil.Number - value.Number);
            
            var roundedNumber = diffCeil <= diffFloor ? ceil : floor;
            return roundedNumber;
        }
    }
}