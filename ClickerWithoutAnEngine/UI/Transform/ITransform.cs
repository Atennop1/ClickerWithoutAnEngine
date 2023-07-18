using System.Numerics;

namespace ClickerWithoutAnEngine.UI
{
    public interface ITransform : IReadOnlyTransform
    {
        void Teleport(Vector3 position);
        void Rotate(Quaternion rotation);
    }
}