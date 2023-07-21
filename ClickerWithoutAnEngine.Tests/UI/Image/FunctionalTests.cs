using System.Drawing;
using ClickerWithoutAnEngine.UI;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.Image
{
    public sealed class FunctionalTests
    {
        private IImage _image;

        [SetUp]
        public void Setup()
        {
            var graphics = Graphics.FromImage(new Bitmap(200, 200));
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(new ClickerWithoutAnEngine.UI.Transform());
            _image = new ClickerWithoutAnEngine.UI.Image(interfaceElement, graphics, new Bitmap(50, 50));
        }
        
        [Test]
        public void IsDrawCorrect()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _image.Disable();
                _image.Draw();
            });
        }
        
        [Test]
        public void IsChangeColorCorrect()
        {
            _image.ChangeColor(Color.White);
            Assert.That(_image.Color == Color.White);
        }
        
        [Test]
        public void IsEnableCorrect1() 
            => Assert.That(() => _image.IsEnabled);

        [Test]
        public void IsEnableCorrect2()
        {
            _image.Enable();
            Assert.That(() => _image.IsEnabled);
        }

        [Test]
        public void IsDisableCorrect1()
        {
            _image.Disable();
            Assert.That(() => !_image.IsEnabled);
        }
        
        [Test]
        public void IsDisableCorrect2()
        {
            _image.Disable();
            _image.Disable();
            Assert.That(() => !_image.IsEnabled);
        }
    }
}