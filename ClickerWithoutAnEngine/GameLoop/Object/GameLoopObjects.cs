namespace ClickerWithoutAnEngine.GameLoop.Object
{
    public sealed class GameLoopObjects : IGameLoopObject
    {
        private readonly List<IGameLoopObject> _gameLoopObjects;

        public GameLoopObjects(List<IGameLoopObject> gameLoopObjects) 
            => _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));

        public void Update(float deltaTime) 
            => _gameLoopObjects.ForEach(gameLoopObject => gameLoopObject.Update(deltaTime));
    }
}