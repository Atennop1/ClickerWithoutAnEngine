using System.Drawing;

namespace ClickerWithoutAnEngine.UI
{
    public interface IReadOnlyText : IReadOnlyInterfaceElement
    {
        string Line { get; }
        Color Color { get; }
    }
}