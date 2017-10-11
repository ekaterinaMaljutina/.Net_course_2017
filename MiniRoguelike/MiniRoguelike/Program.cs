using System;
using MiniRoguelike.GameMap;
using MiniRoguelike.Player;

namespace MiniRoguelike
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var map = new WorldMap();
            var hero = new Hero(map);
            var world = new DrawWorld(map, hero);

            var eventLoop = new EventLoop();

            eventLoop.LeftHandler += world.Left;
            eventLoop.RightHandler += world.Right;
            eventLoop.UpHandler += world.Up;
            eventLoop.DownHandler += world.Down;
            eventLoop.ShutDown += world.End; 

            eventLoop.Run();
        }
    }
        
}
