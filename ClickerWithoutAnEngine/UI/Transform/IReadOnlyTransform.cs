using System.Numerics;

namespace ClickerWithoutAnEngine.UI
{
    public interface IReadOnlyTransform
    {
        Vector2 Position { get; }
        Quaternion Rotation { get; }

        bool CanTeleport(Vector2 position);
        bool CanRotate(Quaternion rotation);
    }
}