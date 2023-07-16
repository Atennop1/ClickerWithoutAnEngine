using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.Score
{
    public sealed class CreationTests
    {
        [Test]
        public void IsCreationCorrect1() 
            => Assert.Throws<ArgumentNullException>(() => new ClickerWithoutAnEngine.Score.Score(null!));

        [Test]
        public void IsCreationCorrect2()
        {
            var score = new ClickerWithoutAnEngine.Score.Score(new Math.ExponentialNumber(3.2D, 10));
            Assert.That(score.Value is { Exponent: 10, Number: 3.2D });
        }
        
        [Test]
        public void IsCreationCorrect3()
        {
            var score = new ClickerWithoutAnEngine.Score.Score();
            Assert.That(score.Value is { Exponent: 0, Number: 0D });
        }
    }
}