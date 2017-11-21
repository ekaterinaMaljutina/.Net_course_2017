using System;
using System.Threading.Tasks;
using MiniRoguelike.GameMap;
using MiniRoguelike.Player;

namespace MiniRoguelike
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            var map = new WorldMap();
            var hero = new Hero(map);
            hero.InitFirstPosition();
            var world = new DrawWorld(map, hero);

            Console.CancelKeyPress += (sender, eventArgs) => Environment.Exit(0);

            var taskKeys = new Task(() => ReadKeys(world));
            taskKeys.Start();
            var tasks = new[] {taskKeys};
            Task.WaitAll(tasks);
        }

        private static void ReadKeys(DrawWorld drawWorld)
        {
            var keyInfo = new ConsoleKeyInfo();
            while (!Console.KeyAvailable && keyInfo.Key != ConsoleKey.Escape)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        drawWorld.Left();
                        break;
                    case ConsoleKey.RightArrow:
                        drawWorld.Right();
                        break;
                    case ConsoleKey.UpArrow:
                        drawWorld.Up();
                        break;
                    case ConsoleKey.DownArrow:
                        drawWorld.Down();
                        break;
                }
            }
        }
    }
}