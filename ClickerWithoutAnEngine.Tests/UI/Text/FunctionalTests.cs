using System.Drawing;
using ClickerWithoutAnEngine.UI;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.Text
{
    public sealed class FunctionalTests
    {
        private IText _text;

        [SetUp]
        public void Setup()
        {
            var graphics = Graphics.FromImage(new Bitmap(200, 200));
            var interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(new ClickerWithoutAnEngine.UI.Transform());
            _text = new ClickerWithoutAnEngine.UI.Text(interfaceElement, graphics, new Font("Arial", 14));
        }

        [Test]
        public void IsDisplayCorrect1()
            => Assert.Throws<ArgumentNullException>(() => _text.DisplayLine(null!));
        
        [Test]
        public void IsDisplayCorrect2()
        {
            _text.DisplayLine("Hello!");
            Assert.That(_text.Line == "Hello!");
        }
        
        [Test]
        public void IsDisplayCorrect3()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _text.Disable();
                _text.DisplayLine("Hello!");
            });
        }

        [Test]
        public void IsChangeColorCorrect()
        {
            _text.ChangeColor(Color.Indigo);
            Assert.That(_text.Color == Color.Indigo);
        }

        [Test]
        public void IsDisableCorrect1()
        {
            _text.DisplayLine("Hello!");
            _text.Disable();
            Assert.That(_text is { Line: "", IsEnabled: false });
        }
        
        [Test]
        public void IsDisableCorrect2()
        {
            _text.DisplayLine("Hello!");
            _text.Disable();
            _text.Disable();
            Assert.That(_text is { Line: "", IsEnabled: false });
        }

        [Test]
        public void IsEnableCorrect1()
        {
            _text.DisplayLine("Hello!");
            _text.Disable();
            
            var lineLengthAfterDisabling = _text.Line.Length;
            _text.Enable();
            
            Assert.That(_text.Line == "Hello!" && lineLengthAfterDisabling == 0 && _text.IsEnabled);
        }
        
        [Test]
        public void IsEnableCorrect2()
        {
            _text.DisplayLine("Hello!");
            _text.Disable();
            
            var lineLengthAfterDisabling = _text.Line.Length;
            _text.Enable();
            _text.Enable();
            
            Assert.That(_text.Line == "Hello!" && lineLengthAfterDisabling == 0 && _text.IsEnabled);
        }
    }
}