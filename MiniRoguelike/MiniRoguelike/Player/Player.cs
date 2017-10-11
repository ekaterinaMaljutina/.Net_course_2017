using System;
using MiniRoguelike.GameMap;

namespace MiniRoguelike.Player
{
    public class Hero
    {
        public int x { get; private set; }

        public int y { get; private set; }

        public readonly WorldMap _map;

        public Hero(WorldMap _map)
        {
            this._map = _map;
            InitFirstPosition();
        }

        public void InitFirstPosition()
        {
            var position = _map.getFirstEmptyPosition();
            if (position.Item1 == -1 && position.Item2 == -1)
            {
                throw new PlayerPositionException(" Empty position is not found");   
            }
            x = position.Item1;
            y = position.Item2;
        }

        public void MoveLevt()
        {
            UpdatePosotion(x, y - 1);
        }

        public void MoveRight()
        {
            UpdatePosotion(x , y + 1);
        }

        public void MoveUp()
        {
            UpdatePosotion(x - 1, y );
        }

        public void MoveDown()
        {
            UpdatePosotion(x + 1, y );
        }


        private void UpdatePosotion(int x, int y)
        {
            if (_map.IsEmptyCell(x, y))
            {
                this.x = x;
                this.y = y;
            }
        }

    }

    public class PlayerPositionException : Exception
    {
        public PlayerPositionException(string message)
            : base(message)
        {
        }
        
    }
}

