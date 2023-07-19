using System.Drawing;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.Text
{
    public sealed class CreationTests
    {
        [Test]
        public void IsCreationCorrect1()
        {
            var bitmap = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bitmap);
            Assert.Throws<ArgumentNullException>(() => { var text = new ClickerWithoutAnEngine.UI.Text(null!, graphics, new Font("Arial", 14)); });
        }
        
        [Test]
        public void IsCreationCorrect2()
        {
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(new ClickerWithoutAnEngine.UI.Transform());
            Assert.Throws<ArgumentNullException>(() => { var text = new ClickerWithoutAnEngine.UI.Text(interfaceElement, null!, new Font("Arial", 14)); });
        }
        
        [Test]
        public void IsCreationCorrect3()
        {
            var bitmap = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bitmap);
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(new ClickerWithoutAnEngine.UI.Transform());
            Assert.Throws<ArgumentNullException>(() => { var text = new ClickerWithoutAnEngine.UI.Text(interfaceElement, graphics, null!); });
        }
        
        [Test]
        public void IsCreationCorrect4()
        {
            var bitmap = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bitmap);
            var transform = new ClickerWithoutAnEngine.UI.Transform();
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(transform);
            
            var text = new ClickerWithoutAnEngine.UI.Text(interfaceElement, graphics, new Font("Arial", 14));
            Assert.That(text.Transform == transform && text.Color == Color.Black && text.Line == string.Empty);
        }
    }
}