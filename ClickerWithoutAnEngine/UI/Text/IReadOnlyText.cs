using System.Drawing;

namespace ClickerWithoutAnEngine.UI
{
    public interface IReadOnlyText
    {
        string Line { get; }
        Color Color { get; }
    }
}