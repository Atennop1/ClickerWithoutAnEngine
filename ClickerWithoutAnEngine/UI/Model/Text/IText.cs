using System.Drawing;

namespace ClickerWithoutAnEngine.UI
{
    public interface IText : IReadOnlyText, IInterfaceElement
    {
        void DisplayLine(string line);
        void ChangeColor(Color color);
    }
}