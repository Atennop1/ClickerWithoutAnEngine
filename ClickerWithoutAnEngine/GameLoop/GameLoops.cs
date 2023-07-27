namespace ClickerWithoutAnEngine.GameLoop
{
    public sealed class GameLoops : IGameLoop
    {
        private readonly List<IGameLoop> _gameLoops;

        public GameLoops(List<IGameLoop> gameLoops) 
            => _gameLoops = gameLoops ?? throw new ArgumentNullException(nameof(gameLoops));

        public void Activate() 
            => _gameLoops.ForEach(loop => loop.Activate());
    }
}