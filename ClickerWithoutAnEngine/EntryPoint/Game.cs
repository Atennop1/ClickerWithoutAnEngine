using System.Drawing;
using ClickerWithoutAnEngine.GameLoop;
using ClickerWithoutAnEngine.Tools;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            var bitmap = new Bitmap("C:\\Unity\\LearningStuff\\Assets\\Sprites\\Anatoliy.jpg");
            bitmap.ChangeColor(Color.FromArgb(105, 148, 105));
            bitmap.Save("C:\\Users\\User\\image.png");
            
            var loopObjects = new GameLoopObjects(new List<IGameLoopObject>
            {

            });

            var gamePause = new GamePause();
            var gameLoop = new GameLoop.GameLoop(loopObjects, gamePause);
            gameLoop.Activate();
        }
    }
}