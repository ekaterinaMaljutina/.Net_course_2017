using System;
using MiniRoguelike.GameMap;
using MiniRoguelike.Player;

namespace MiniRoguelike
{
    public class DrawWorld
    {
        private WorldMap _map;
        private Hero _player;

        public DrawWorld(WorldMap _map, Hero _player)
        {
            this._map = _map;
            this._player = _player;

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

        public void End()
        {
            Shutdown();
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
            Console.SetCursorPosition(_player.y, _player.x);
            Console.Write(CellType.PLAYER);
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);

        }

        private void Shutdown()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("GOOD BYE");
            Console.ResetColor();  
        }
    }
}

