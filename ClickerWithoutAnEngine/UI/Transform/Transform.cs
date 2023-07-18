using System.Numerics;

namespace ClickerWithoutAnEngine.UI
{
    public sealed class Transform : ITransform
    {
        public Transform(Vector3 position = new(), Quaternion rotation = new())
        {
            Position = position;
            Rotation = rotation;
        }

        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public bool CanTeleport(Vector3 position)
            => Position != position;
        
        public void Teleport(Vector3 position)
        {
            if (!CanTeleport(position))
                throw new InvalidOperationException("Transform is already in that position");
            
            Position = position;
        }

        public bool CanRotate(Quaternion rotation)
            => Rotation != rotation;

        public void Rotate(Quaternion rotation)
        {
            if (!CanRotate(rotation))
                throw new InvalidOperationException("Transform is already in that rotation");

            
            Rotation = rotation;
        }
    }
}