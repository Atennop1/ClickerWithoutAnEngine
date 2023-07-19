using System.Numerics;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.InterfaceElement
{
    public sealed class CreationTests
    {
        [Test]
        public void IsCreationCorrect1()
            => Assert.Throws<ArgumentNullException>(() => { var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(null!); });
        
        [Test]
        public void IsCreationCorrect2()
        {
            var transform = new ClickerWithoutAnEngine.UI.Transform(new Vector2(5, 5));
            var element = new ClickerWithoutAnEngine.UI.InterfaceElement(transform);
            Assert.That(element.Transform == transform && element.IsEnabled);
        }
        
        [Test]
        public void IsCreationCorrect3()
        {
            var transform = new ClickerWithoutAnEngine.UI.Transform(new Vector2(5, 5));
            var element = new ClickerWithoutAnEngine.UI.InterfaceElement(transform, false);
            Assert.That(element.Transform == transform && !element.IsEnabled);
        }
    }
}