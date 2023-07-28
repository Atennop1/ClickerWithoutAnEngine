using System.Drawing;

namespace ClickerWithoutAnEngine.UI
{
    public interface IReadOnlyImage : IReadOnlyInterfaceElement
    {
        Color Color { get; }
    }
}