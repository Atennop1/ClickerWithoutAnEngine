using System.Drawing;

namespace ClickerWithoutAnEngine.UI
{
    public interface IImage : IReadOnlyImage, IInterfaceElement
    {
        void Draw();
        void ChangeColor(Color color);
    }
}