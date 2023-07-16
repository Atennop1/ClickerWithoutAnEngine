using ClickerWithoutAnEngine.Math;
using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.Score
{
    public sealed class MultipliedScore : IMultipliedScore
    {
        private readonly IScore _score;

        public MultipliedScore(IScore score, float multiplicationCoefficient = 1f)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            MultiplicationCoefficient = multiplicationCoefficient.ThrowExceptionIfLessOrEqualsZero();
        }

        public float MultiplicationCoefficient { get; private set;  }

        public bool CanIncreaseCoefficient(float value)
            => value > 0;

        public void IncreaseCoefficient(float value)
        {
            if (!CanIncreaseCoefficient(value))
                throw new InvalidOperationException($"Can't increase coefficient by {value}");

            MultiplicationCoefficient += value;
        }

        public bool CanDecreaseCoefficient(float value)
            => value > 0 && MultiplicationCoefficient - value > 0;

        public void DecreaseCoefficient(float value)
        {
            if (!CanDecreaseCoefficient(value))
                throw new InvalidOperationException($"Can't decrease coefficient by {value}");

            MultiplicationCoefficient -= value;
        }


        public IExponentialNumber Value 
            => _score.Value;
        
        public bool CanIncrease(IExponentialNumber number) 
            => _score.CanIncrease(number);
        
        public void Increase(IExponentialNumber number) 
            => _score.Increase(number.Multiply(MultiplicationCoefficient));

        public bool CanDecrease(IExponentialNumber number) 
            => _score.CanDecrease(number);

        public void Decrease(IExponentialNumber number)
            => _score.Decrease(number.Multiply(MultiplicationCoefficient));
    }
}