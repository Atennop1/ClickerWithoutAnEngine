using ClickerWithoutAnEngine.Score;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.Score.Multiplied
{
    public sealed class CreationTests
    {
        [Test]
        public void IsCreationCorrect1() 
            => Assert.Throws<ArgumentNullException>(() => new MultipliedScore(null!));

        [Test]
        public void IsCreationCorrect2()
            => Assert.Throws<ArgumentException>(() => new MultipliedScore(new ClickerWithoutAnEngine.Score.Score(), -1));
        
        [Test]
        public void IsCreationCorrect3()
            => Assert.Throws<ArgumentException>(() => new MultipliedScore(new ClickerWithoutAnEngine.Score.Score(), 0));

        [Test]
        public void IsCreationCorrect4()
        {
            var score = new ClickerWithoutAnEngine.Score.Score();
            var multipliedScore = new MultipliedScore(score, 1.4f);
            Assert.That(multipliedScore.MultiplicationCoefficient == 1.4f);
        }
    }
}