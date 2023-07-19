﻿using ClickerWithoutAnEngine.GameLoop;
using System.Drawing;

namespace ClickerWithoutAnEngine.EntryPoint
{
    public sealed class Game
    {
        public void Play()
        {
            var panel = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(panel);

            var font = new Font("Arial", 30);
            var brush = new SolidBrush(Color.Black);
            graphics.DrawString("Hello, World!", font, brush, 100, 100);

            var loopObjects = new GameLoopObjects(new List<IGameLoopObject>
            {

            });

            var gamePause = new GamePause();
            var gameLoop = new GameLoop.GameLoop(loopObjects, gamePause);
            gameLoop.Activate();
        }
    }
}