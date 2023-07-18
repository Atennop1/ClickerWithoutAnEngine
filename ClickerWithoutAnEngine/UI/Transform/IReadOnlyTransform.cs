using System.Numerics;

namespace ClickerWithoutAnEngine.UI
{
    public interface IReadOnlyTransform
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }

        bool CanTeleport(Vector3 position);
        bool CanRotate(Quaternion rotation);
    }
}