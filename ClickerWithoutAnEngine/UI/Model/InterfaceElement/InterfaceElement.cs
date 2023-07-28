namespace ClickerWithoutAnEngine.UI
{
    public sealed class InterfaceElement : IInterfaceElement
    {
        public InterfaceElement(ITransform transform, bool isEnabled = true)
        {
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
            IsEnabled = isEnabled;
        }

        public ITransform Transform { get; }
        public bool IsEnabled { get; private set; }

        public void Enable()
            => IsEnabled = true;

        public void Disable()
            => IsEnabled = false;
    }
}