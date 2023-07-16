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

        public bool CanIncrease(float value)
            => value > 0;

        public void Increase(float value)
        {
            if (!CanIncrease(value))
                throw new InvalidOperationException($"Can't increase coefficient by {value}");

            MultiplicationCoefficient += value;
        }

        public bool CanDecrease(float value)
            => value > 0 && MultiplicationCoefficient - value > 0;

        public void Decrease(float value)
        {
            if (!CanDecrease(value))
                throw new InvalidOperationException($"Can't decrease coefficient by {value}");

            MultiplicationCoefficient -= value;
        }


        public IExponentialNumber Value 
            => _scoreImplementation.Value;
        
        bool IReadOnlyScore.CanIncrease(IExponentialNumber number) 
            => _scoreImplementation.CanIncrease(number);
        
        void IScore.Increase(IExponentialNumber number) 
            => _scoreImplementation.Increase(number.Multiply(MultiplicationCoefficient));

        bool IReadOnlyScore.CanDecrease(IExponentialNumber number) 
            => _scoreImplementation.CanDecrease(number);

        void IScore.Decrease(IExponentialNumber number)
            => _scoreImplementation.Decrease(number.Multiply(MultiplicationCoefficient));
    }
}