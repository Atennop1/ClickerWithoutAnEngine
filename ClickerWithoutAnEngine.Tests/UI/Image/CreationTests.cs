using System.Drawing;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.Image
{
    public sealed class CreationTests
    {
        [Test]
        public void IsCreationCorrect1()
        {
            var bitmap = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bitmap);
            Assert.Throws<ArgumentNullException>(() => { var image = new ClickerWithoutAnEngine.UI.Image(null!, graphics, new Bitmap(50, 50)); });
        }
        
        [Test]
        public void IsCreationCorrect2()
        {
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(new ClickerWithoutAnEngine.UI.Transform());
            Assert.Throws<ArgumentNullException>(() => { var image = new ClickerWithoutAnEngine.UI.Image(interfaceElement, null!, new Bitmap(50, 50)); });
        }
        
        [Test]
        public void IsCreationCorrect3()
        {
            var bitmap = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bitmap);
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(new ClickerWithoutAnEngine.UI.Transform());
            Assert.Throws<ArgumentNullException>(() => { var image = new ClickerWithoutAnEngine.UI.Image(interfaceElement, graphics, null!); });
        }
        
        [Test]
        public void IsCreationCorrect4()
        {
            var bitmap = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bitmap);
            var transform = new ClickerWithoutAnEngine.UI.Transform();
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(transform);
            
            var image = new ClickerWithoutAnEngine.UI.Image(interfaceElement, graphics, new Bitmap(50, 50));
            Assert.That(image.Transform == transform && image.Color == Color.White);
        }
    }
}