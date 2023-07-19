using ClickerWithoutAnEngine.GameLoop;
using System.Drawing;
using System.Numerics;
using ClickerWithoutAnEngine.UI;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            var panel = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(panel);
            var font = new Font("Arial", 30);
            
            var textTransform = new Transform(new Vector2(100, 100));
            var interfaceElement = new InterfaceElement(textTransform);
            var text = new Text(interfaceElement, graphics, font);
            
            text.DisplayLine("Hello, World!");

            var loopObjects = new GameLoopObjects(new List<IGameLoopObject>
            {

            });

            var gamePause = new GamePause();
            var gameLoop = new GameLoop.GameLoop(loopObjects, gamePause);
            gameLoop.Activate();
        }
    }
}