using ClickerWithoutAnEngine.Score;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.Score.Multiplied
{
    public sealed class FunctionalTests
    {
        private IMultipliedScore _multipliedScore;

        [SetUp]
        public void Setup() 
            => _multipliedScore = new MultipliedScore(new ClickerWithoutAnEngine.Score.Score(), 1.5f);

        [Test]
        public void IsIncreaseCoefficientCorrect1()
            => Assert.Throws<InvalidOperationException>(() => _multipliedScore.IncreaseCoefficient(-1));

        [Test]
        public void IsIncreaseCoefficientCorrect2()
        {
            _multipliedScore.IncreaseCoefficient(0.5f);
            Assert.That(_multipliedScore.MultiplicationCoefficient == 2.0f);
        }
        
        [Test]
        public void IsDecreaseCoefficientCorrect1()
            => Assert.Throws<InvalidOperationException>(() => _multipliedScore.DecreaseCoefficient(-1));
        
        [Test]
        public void IsDecreaseCoefficientCorrect2()
            => Assert.Throws<InvalidOperationException>(() => _multipliedScore.DecreaseCoefficient(1.5f));

        [Test]
        public void IsDecreaseCoefficientCorrect3()
        {
            _multipliedScore.DecreaseCoefficient(0.4f);
            Assert.That(_multipliedScore.MultiplicationCoefficient == 1.1f);
        }

        [Test]
        public void IsIncreaseCorrect1()
            => Assert.Throws<NullReferenceException>(() => _multipliedScore.Increase(null!));

        [Test]
        public void IsIncreaseCorrect2()
        {
            _multipliedScore.Increase(new Math.ExponentialNumber(6));
            Assert.That(_multipliedScore.Value is { Number: 9, Exponent: 0 });
        }
        
        [Test]
        public void IsDecreaseCorrect1()
            => Assert.Throws<NullReferenceException>(() => _multipliedScore.Decrease(null!));

        [Test]
        public void IsDecreaseCorrect2()
        {
            _multipliedScore.Increase(new Math.ExponentialNumber(6));
            _multipliedScore.Decrease(new Math.ExponentialNumber(4));
            Assert.That(_multipliedScore.Value is { Number: 3, Exponent: 0 });
        }
    }
}