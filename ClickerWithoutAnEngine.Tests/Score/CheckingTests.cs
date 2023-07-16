using ClickerWithoutAnEngine.Score;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.Score
{
    public sealed class CheckingTests
    {
        private IScore _score;

        [OneTimeSetUp]
        public void Setup() 
            => _score = new ClickerWithoutAnEngine.Score.Score();

        [Test]
        public void IsCanIncreaseCorrect1() 
            => Assert.That(_score.CanIncrease(null!) == false);
        
        [Test]
        public void IsCanIncreaseCorrect2() 
            => Assert.That(_score.CanIncrease(new Math.ExponentialNumber(-1)) == false);
        
        [Test]
        public void IsCanIncreaseCorrect3() 
            => Assert.That(_score.CanIncrease(new Math.ExponentialNumber(5)));
        
        [Test]
        public void IsCanDecreaseCorrect1() 
            => Assert.That(_score.CanDecrease(null!) == false);
        
        [Test]
        public void IsCanDecreaseCorrect2() 
            => Assert.That(_score.CanDecrease(new Math.ExponentialNumber(-1)) == false);
        
        [Test]
        public void IsCanDecreaseCorrect3() 
            => Assert.That(_score.CanDecrease(new Math.ExponentialNumber(5)) == false);
        
        [Test]
        public void IsCanDecreaseCorrect4()
        {
            _score.Increase(new Math.ExponentialNumber(10));
            Assert.That(_score.CanDecrease(new Math.ExponentialNumber(5)));
        }
    }
}