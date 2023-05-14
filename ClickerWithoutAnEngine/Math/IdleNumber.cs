namespace ClickerWithoutAnEngine.Math
{
    public sealed class IdleNumber : IIdleNumber
    {
        public float Number { get; }
        public int Exponent { get; }

        public IdleNumber(float number = 0f, int exponent = 0)
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
            }

            Exponent = exponent;
            Number = number;
        }

        public IdleNumber(IIdleNumber idleNumber)
        {
            Exponent = idleNumber.Exponent;
            Number = idleNumber.Number;
        }
    }
}