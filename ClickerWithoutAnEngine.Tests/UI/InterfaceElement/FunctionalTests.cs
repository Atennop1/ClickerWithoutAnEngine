using ClickerWithoutAnEngine.UI;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.UI.InterfaceElement
{
    public sealed class FunctionalTests
    {
        private IInterfaceElement _interfaceElement;

        [SetUp]
        public void Setup()
            => _interfaceElement = new ClickerWithoutAnEngine.UI.InterfaceElement(new ClickerWithoutAnEngine.UI.Transform());

        [Test]
        public void IsEnableCorrect1()
        {
            _interfaceElement.Enable();
            Assert.That(() => _interfaceElement.IsEnabled);
        }
        
        [Test]
        public void IsEnableCorrect2()
        {
            _interfaceElement.Enable();
            _interfaceElement.Enable();
            Assert.That(() => _interfaceElement.IsEnabled);
        }

        [Test]
        public void IsDisableCorrect1()
        {
            _interfaceElement.Enable();
            _interfaceElement.Disable();
            Assert.That(() => !_interfaceElement.IsEnabled);
        }
        
        [Test]
        public void IsDisableCorrect2()
        {
            _interfaceElement.Disable();
            Assert.That(() => !_interfaceElement.IsEnabled);
        }
    }
}