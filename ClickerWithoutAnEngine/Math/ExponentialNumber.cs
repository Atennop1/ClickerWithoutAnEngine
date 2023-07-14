namespace ClickerWithoutAnEngine.Math
{
    public sealed class ExponentialNumber : IExponentialNumber
    {
        public double Number { get; }
        public int Exponent { get; }

        public ExponentialNumber(double number = 0f, int exponent = 0)
        {
            if (number != 0)
            {
                while (System.Math.Abs(number) >= 10)
                {
                    number /= 10f;
                    exponent++;
                }

                while (System.Math.Abs(number) < 1)
                {
                    number *= 10f;
                    exponent--;
                }
                
                Exponent = exponent;
                Number = number;
                return;
            }

            Exponent = 0;
            Number = 0;
        }

        public ExponentialNumber(IExponentialNumber exponentialNumber)
        {
            Exponent = exponentialNumber.Exponent;
            Number = exponentialNumber.Number;
        }
    }
}