using System.Numerics;
using ClickerWithoutAnEngine.UI;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.Transform
{
    public sealed class CheckingTests
    {
        private ITransform _transform;

        [SetUp]
        public void Setup() 
            => _transform = new ClickerWithoutAnEngine.UI.Transform();

        [Test]
        public void IsCanTeleportCorrect1()
            => Assert.That(_transform.CanTeleport(Vector2.Zero) == false);
        
        [Test]
        public void IsCanTeleportCorrect2()
            => Assert.That(_transform.CanTeleport(new Vector2(3, 5)));
        
        [Test]
        public void IsCanRotateCorrect1()
            => Assert.That(_transform.CanRotate(Quaternion.Identity) == false);
        
        [Test]
        public void IsCanRotateCorrect2()
            => Assert.That(_transform.CanRotate(new Quaternion(1, 3, 4, 6)));
    }
}