using ClickerWithoutAnEngine.GameLoop;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            var gameLoopObjects = new GameLoopObjects(new List<IGameLoopObject>
            {
                
            });

            var renderingLoopObjects = new GameLoopObjects(new List<IGameLoopObject>
            {
                
            });

            var gamePause = new GamePause();
            var gameLoop = new GameLoop.GameLoop(gameLoopObjects, gamePause);
            var renderingLoop = new RenderingLoop(renderingLoopObjects);
            
            var loops = new GameLoops(new List<IGameLoop> { gameLoop, renderingLoop });
            loops.Activate();
        }
    }
}