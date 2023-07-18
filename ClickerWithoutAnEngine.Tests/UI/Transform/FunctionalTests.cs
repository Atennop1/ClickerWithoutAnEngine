using System.Numerics;
using ClickerWithoutAnEngine.UI;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.Transform
{
    public sealed class FunctionalTests
    {
        private ITransform _transform;

        [SetUp]
        public void Setup() 
            => _transform = new ClickerWithoutAnEngine.UI.Transform();

        [Test]
        public void IsTeleportCorrect1()
            => Assert.Throws<InvalidOperationException>(() => _transform.Teleport(Vector2.Zero));

        [Test]
        public void IsTeleportCorrect2()
        {
            _transform.Teleport(new Vector2(4, 5));
            Assert.That(_transform.Position is { X: 4, Y: 5 });
        }
        
        [Test]
        public void IsRotateCorrect1()
            => Assert.Throws<InvalidOperationException>(() => _transform.Rotate(Quaternion.Identity));

        [Test]
        public void IsRotateCorrect2()
        {
            _transform.Rotate(new Quaternion(4, 5, 8, 10));
            Assert.That(_transform.Rotation is { X: 4, Y: 5, Z: 8, W: 10 });
        }
    }
}