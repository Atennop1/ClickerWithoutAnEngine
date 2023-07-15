using ClickerWithoutAnEngine.GameLoop;
using ClickerWithoutAnEngine.GameLoop.Object;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            Console.WriteLine("There will be a console game soon ;)");
            
            var loopObject = new ExampleLoopObject();
            var loopObjects = new GameLoopObjects(new List<IGameLoopObject> { loopObject });

            var gamePause = new GamePause();
            var gameLoop = new GameLoop.GameLoop(loopObjects, gamePause);
            gameLoop.Activate();
        }
    }

    public class ExampleLoopObject : IGameLoopObject
    {
        public void Update(float deltaTime) 
            => Console.WriteLine("Updated");
    }
}