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

            var roundedNumber = (int)System.Math.Floor(System.Math.Abs(expandedNumber));
            roundedNumber *= System.Math.Sign(expandedNumber);

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

            if (value.Number == 0)
                return new IdleNumber();
            
            return value.Number > 0 
                ? new IdleNumber(roundedNumber, value.Exponent) 
                : new IdleNumber(roundedNumber - (float)(1 / System.Math.Pow(10, decimalPlaces)), value.Exponent);
        }

        public static IIdleNumber Round(this IIdleNumber value)
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