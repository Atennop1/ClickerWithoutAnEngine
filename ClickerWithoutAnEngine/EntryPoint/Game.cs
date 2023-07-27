using ClickerWithoutAnEngine.GameLoop;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            OpenGL.Platform.Window.CreateWindow("CookieClicker", 1280, 720);

            while (OpenGL.Platform.Window.Open) 
                OpenGL.Platform.Window.HandleEvents();

            var loopObjects = new GameLoopObjects(new List<IGameLoopObject>
            {

            });

            var gamePause = new GamePause();
            var gameLoop = new GameLoop.GameLoop(loopObjects, gamePause);
            gameLoop.Activate();
        }
    }
}