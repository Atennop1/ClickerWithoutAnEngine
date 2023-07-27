using System.Diagnostics;

namespace ClickerWithoutAnEngine.GameLoop
{
    public sealed class RenderingLoop : IGameLoop
    {
        private readonly IGameLoopObject _gameLoopObject;
        private readonly Stopwatch _stopwatch = new();

        public RenderingLoop(IGameLoopObject gameLoopObject) 
            => _gameLoopObject = gameLoopObject ?? throw new ArgumentNullException(nameof(gameLoopObject));

        public void Activate()
        {
            _stopwatch.Start();
            var lastUpdateTime = _stopwatch.Elapsed;
            
            OpenGL.Platform.Window.CreateWindow("CookieClicker", 1920, 1280);
            
            var updatingThread = new Thread(() =>
            {
                while (OpenGL.Platform.Window.Open)
                {
                    OpenGL.Platform.Window.HandleEvents();
                    
                    var deltaTime = _stopwatch.Elapsed - lastUpdateTime;
                    lastUpdateTime += deltaTime;

                    var deltaTimeInSeconds = (float)deltaTime.TotalSeconds;
                    _gameLoopObject.Update(deltaTimeInSeconds);
                }
            });
            
            updatingThread.Start();
        }
    }
}