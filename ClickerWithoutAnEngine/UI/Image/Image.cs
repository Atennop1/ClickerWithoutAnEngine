using System.Drawing;
using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.UI
{
    public sealed class Image : IImage
    {
        private readonly IInterfaceElement _interfaceElement;
        private readonly Graphics _graphics;
        private readonly Bitmap _bitmap;

        public Image(IInterfaceElement interfaceElement, Graphics graphics, Bitmap bitmap)
        {
            _interfaceElement = interfaceElement ?? throw new ArgumentNullException(nameof(interfaceElement));
            _graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            _bitmap = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
        }

        public ITransform Transform 
            => _interfaceElement.Transform;

        public bool IsEnabled 
            => _interfaceElement.IsEnabled;
        
        public Color Color { get; private set; } = Color.White;

        public void Draw()
        {
            if (!IsEnabled)
                throw new InvalidOperationException("Can't draw disabled image");
            
            _graphics.DrawImage(_bitmap, Transform.Position.X, Transform.Position.Y);
        }

        public void ChangeColor(Color color)
        {
            Color = color;
            _bitmap.SwitchColor(Color);
            Draw();
        }
        
        public void Enable()
        {
            _interfaceElement.Enable();
            Draw();
        }

        public void Disable()
        {
            _interfaceElement.Disable();
            _bitmap.Dispose(); //TODO change this to setting bitmap an empty image and draw it
        }
    }
}