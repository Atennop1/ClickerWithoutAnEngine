using ClickerWithoutAnEngine.GameLoop;
using ClickerWithoutAnEngine.GameLoop.Object;
using System.Drawing;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            using var panel = new Bitmap(200, 200);
            using var graphics = Graphics.FromImage(panel);

            var font = new Font("Arial", 30);
            var brush = new SolidBrush(Color.Black);
            graphics.DrawString("Hello, World!", font, brush, 0, 0);

            var loopObjects = new GameLoopObjects(new List<IGameLoopObject>
            {

            });

            var gamePause = new GamePause();
            var gameLoop = new GameLoop.GameLoop(loopObjects, gamePause);
            gameLoop.Activate();
        }
    }
}