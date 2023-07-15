namespace ClickerWithoutAnEngine.GameLoop
{
    public sealed class GamePause : IGamePause
    {
        public bool IsActive { get; private set; }
        
        public void Activate()
        {
            if (IsActive)
                throw new InvalidOperationException("Pause is already enabled");
            
            IsActive = true;
        }

        public void Deactivate()
        {
            if (!IsActive)
                throw new InvalidOperationException("Pause is already disabled");
            
            IsActive = false;
        }
    }
}