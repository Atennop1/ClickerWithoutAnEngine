using ClickerWithoutAnEngine.Score;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.Score
{
    public sealed class FunctionalTests
    {
        private IScore _score;

        [SetUp]
        public void Setup() 
            => _score = new ClickerWithoutAnEngine.Score.Score();

        [Test]
        public void IsIncreaseCorrect1()
            => Assert.Throws<InvalidOperationException>(() => _score.Increase(new Math.ExponentialNumber(-1)));

        [Test]
        public void IsIncreaseCorrect2()
        {
            _score.Increase(new Math.ExponentialNumber(15));
            Assert.That(_score.Value is { Number: 1.5d, Exponent: 1 });
        }
        
        [Test]
        public void IsDecreaseCorrect1()
            => Assert.Throws<InvalidOperationException>(() => _score.Decrease(new Math.ExponentialNumber(-1)));
        
        [Test]
        public void IsDecreaseCorrect2()
            => Assert.Throws<InvalidOperationException>(() => _score.Decrease(new Math.ExponentialNumber(1)));

        [Test]
        public void IsDecreaseCorrect3()
        {
            _score.Increase(new Math.ExponentialNumber(15));
            _score.Decrease(new Math.ExponentialNumber(10));
            Assert.That(_score.Value is { Number: 5d, Exponent: 0 });
        }
    }
}