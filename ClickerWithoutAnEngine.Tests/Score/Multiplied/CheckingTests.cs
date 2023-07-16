using ClickerWithoutAnEngine.Score;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.Score.Multiplied
{
    public sealed class CheckingTests
    {
        private IMultipliedScore _multipliedScore;

        [OneTimeSetUp]
        public void Setup() 
            => _multipliedScore = new MultipliedScore(new ClickerWithoutAnEngine.Score.Score());

        [Test]
        public void IsCanIncreaseCoefficientCorrect1() 
            => Assert.That(_multipliedScore.CanIncreaseCoefficient(-0.2f) == false);
        
        [Test]
        public void IsCanIncreaseCoefficientCorrect2() 
            => Assert.That(_multipliedScore.CanIncreaseCoefficient(0.3f));

        [Test]
        public void IsCanDecreaseCoefficientCorrect1() 
            => Assert.That(_multipliedScore.CanDecreaseCoefficient(-0.4f) == false);
        
        [Test]
        public void IsCanDecreaseCoefficientCorrect2() 
            => Assert.That(_multipliedScore.CanDecreaseCoefficient(1.4f) == false);
        
        [Test]
        public void IsCanDecreaseCoefficientCorrect3() 
            => Assert.That(_multipliedScore.CanDecreaseCoefficient(0.6f));
    }
}