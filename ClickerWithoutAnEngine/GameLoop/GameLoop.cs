using System.Diagnostics;

namespace ClickerWithoutAnEngine.GameLoop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IGameLoopObject _gameLoopObject;
        private readonly IGamePause _gamePause;
        private readonly Stopwatch _stopwatch = new();

        public GameLoop(IGameLoopObject gameLoopObject, IGamePause gamePause)
        {
            _gameLoopObject = gameLoopObject ?? throw new ArgumentNullException(nameof(gameLoopObject));
            _gamePause = gamePause ?? throw new ArgumentNullException(nameof(gamePause));
        }

        public void Activate()
        {
            _stopwatch.Start();
            var lastUpdateTime = _stopwatch.Elapsed;
            
            while (true)
            {
                if (_gamePause.IsActive)
                    continue;

                var deltaTime = _stopwatch.Elapsed - lastUpdateTime;
                lastUpdateTime += deltaTime;
                
                var deltaTimeInSeconds = (float)deltaTime.TotalSeconds;
                _gameLoopObject.Update(deltaTimeInSeconds);
            }
        }
    }
}