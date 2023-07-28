using ClickerWithoutAnEngine.GameLoop;
using ClickerWithoutAnEngine.UI.OpenGL;
using OpenGL.Platform;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            UserInterface.InitUI(Window.Width, Window.Height);
            
            var welcome = new Text(Shaders.FontShader, new BMFont("C:/Users/User/Downloads/test.fnt"), "Hello world!", BMFont.Justification.Center);
            welcome.RelativeTo = Corner.Center;
            
            UserInterface.AddElement(welcome);
            
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