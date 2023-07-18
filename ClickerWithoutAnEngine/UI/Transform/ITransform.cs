using System.Numerics;

namespace ClickerWithoutAnEngine.UI
{
    public interface ITransform : IReadOnlyTransform
    {
        void Teleport(Vector2 position);
        void Rotate(Quaternion rotation);
    }
}