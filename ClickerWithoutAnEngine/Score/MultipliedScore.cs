using ClickerWithoutAnEngine.Math;
using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.Score
{
    public sealed class MultipliedScore : IMultipliedScore
    {
        private readonly IScore _scoreImplementation;

        public MultipliedScore(IScore scoreImplementation, float multiplicationCoefficient = 1f)
        {
            _scoreImplementation = scoreImplementation ?? throw new ArgumentNullException(nameof(scoreImplementation));
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
            => _scoreImplementation.Value;
        
        public bool CanIncrease(IExponentialNumber number) 
            => _scoreImplementation.CanIncrease(number);
        
        public void Increase(IExponentialNumber number) 
            => _scoreImplementation.Increase(number.Multiply(MultiplicationCoefficient));

        public bool CanDecrease(IExponentialNumber number) 
            => _scoreImplementation.CanDecrease(number);

        public void Decrease(IExponentialNumber number)
            => _scoreImplementation.Decrease(number.Multiply(MultiplicationCoefficient));
    }
}