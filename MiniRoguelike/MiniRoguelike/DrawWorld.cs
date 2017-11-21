using System;
using MiniRoguelike.GameMap;
using MiniRoguelike.Player;

namespace MiniRoguelike
{
    public class DrawWorld 
    {
        private readonly WorldMap _map;
        private readonly Hero _player;

        public DrawWorld(WorldMap map, Hero player)
        {
            _map = map;
            _player = player;

            DrawMapAndPlayer();
        }

        public void Left()
        {
            _player.MoveLevt();
            DrawMapAndPlayer();
        }

        public void Right()
        {
            _player.MoveRight();
            DrawMapAndPlayer();
        }

        public void Up()
        {
            _player.MoveUp();
            DrawMapAndPlayer();
        }

        public void Down()
        {
            _player.MoveDown();
            DrawMapAndPlayer();
        }
        
        private void DrawMapAndPlayer()
        {
            Console.CursorVisible = false;
            _map.Map.ForEach(tuple =>
                {
                    Console.SetCursorPosition(tuple.Item2, tuple.Item1);
                    Console.Write(tuple.Item3);
                });     

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(_player.Y, _player.X);
            Console.Write(CellType.Player);
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);

        }
    }
}

