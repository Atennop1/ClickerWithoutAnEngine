using System.Numerics;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.Transform
{
    public sealed class CreationTests
    {
        [Test]
        public void IsCreationCorrect1()
        {
            var transform = new ClickerWithoutAnEngine.UI.Transform();
            Assert.That(transform.Position is { X: 0, Y: 0 } && transform.Rotation == Quaternion.Identity);
        }
        
        [Test]
        public void IsCreationCorrect2()
        {
            var transform = new ClickerWithoutAnEngine.UI.Transform(new Vector3(5, 5, 5));
            Assert.That(transform.Position is { X: 5, Y: 5 } && transform.Rotation == Quaternion.Identity);
        }
        
        [Test]
        public void IsCreationCorrect3()
        {
            var transform = new ClickerWithoutAnEngine.UI.Transform(new Vector3(5, 5, 5), new Quaternion(1, 3, 4, 6));
            Assert.That(transform.Position is { X: 5, Y: 5 } && transform.Rotation is { X: 1, Y: 3, Z: 4, W: 6 } );
        }
        
        [Test]
        public void IsCreationCorrect4()
        {
            var transform = new ClickerWithoutAnEngine.UI.Transform(new Vector2(5, 5));
            Assert.That(transform.Position is { X: 5, Y: 5 } && transform.Rotation == Quaternion.Identity);
        }
        
        [Test]
        public void IsCreationCorrect5()
        {
            var transform = new ClickerWithoutAnEngine.UI.Transform(new Vector2(5, 5), new Quaternion(1, 3, 4, 6));
            Assert.That(transform.Position is { X: 5, Y: 5 } && transform.Rotation is { X: 1, Y: 3, Z: 4, W: 6 } );
        }
    }
}