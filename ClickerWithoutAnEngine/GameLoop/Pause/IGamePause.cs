namespace ClickerWithoutAnEngine.GameLoop
{
    public interface IGamePause : IReadOnlyGamePause
    {
        void Activate();
        void Deactivate();
    }
}