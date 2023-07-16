using ClickerWithoutAnEngine.Math;

namespace ClickerWithoutAnEngine.Score
{
    public sealed class Score : IScore
    {
        public Score(IExponentialNumber value) 
            => Value = value ?? throw new ArgumentNullException(nameof(value));

        public Score()
            => Value = new ExponentialNumber();
        
        public IExponentialNumber Value { get; private set; }

        public bool CanIncrease(IExponentialNumber number)
            =>  number != null && number.Greater(0);
        
        public void Increase(IExponentialNumber number)
        {
            if (!CanIncrease(number))
                throw new InvalidOperationException($"Can't increase number by value {number}");

            Value = Value.Add(number);
        }

        public bool CanDecrease(IExponentialNumber number)
            => number != null && number.Greater(0) && Value.Subtract(number).GreaterOrEquals(0);

        public void Decrease(IExponentialNumber number)
        {
            if (!CanDecrease(number))
                throw new InvalidOperationException($"Can't decrease number by value {number}");

            Value = Value.Subtract(number);
        }
    }
}