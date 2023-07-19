using System.Drawing;

namespace ClickerWithoutAnEngine.UI
{
    public sealed class Text : IText
    {
        private readonly IInterfaceElement _interfaceElement;
        private readonly Graphics _graphics;
        private readonly Font _font;

        private readonly SolidBrush _brush = new(Color.Black);
        private string _line = string.Empty;

        public Text(IInterfaceElement interfaceElement, Graphics graphics, Font font)
        {
            _interfaceElement = interfaceElement ?? throw new ArgumentNullException(nameof(interfaceElement));
            _graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            _font = font ?? throw new ArgumentNullException(nameof(font));
        }

        public ITransform Transform 
            => _interfaceElement.Transform;

        public bool IsEnabled 
            => _interfaceElement.IsEnabled;

        public Color Color { get; private set; } = Color.Black;
        
        public string Line
        {
            get => IsEnabled ? _line : string.Empty;
            private set => _line = value;
        }

        public void DisplayLine(string line)
        {
            if (!IsEnabled)
                throw new InvalidOperationException("Can't display line in disabled text");
            
            Line = line ?? throw new ArgumentNullException(nameof(line));
            DrawLine(line);
        }

        public void ChangeColor(Color color)
        {
            _brush.Color = Color = color;
            DrawLine(Line);
        }
        
        public void Enable()
        {
            DrawLine(Line);
            _interfaceElement.Enable();
        }

        public void Disable()
        {
            _interfaceElement.Disable();
            DrawLine(string.Empty);
        }
        
        private void DrawLine(string line)
            => _graphics.DrawString(line, _font, _brush, Transform.Position.X, Transform.Position.Y);
    }
}