namespace ClickerWithoutAnEngine.Core
{
    public sealed class IdleNumber : IIdleNumber
    {
        public float Number { get; }
        public int Exponent { get; }

        public IdleNumber(float number = 0f, int exponent = 0)
        {
            while (number > 10)
            {
                number /= 10f;
                exponent++;
            }
                
            while (number < 10)
            {
                number *= 10f;
                exponent--;
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