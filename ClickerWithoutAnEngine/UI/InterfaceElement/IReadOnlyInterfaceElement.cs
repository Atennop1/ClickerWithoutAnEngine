namespace ClickerWithoutAnEngine.UI
{
    public interface IReadOnlyInterfaceElement
    {
        ITransform Transform { get; }
        bool IsEnabled { get; }
    }
}