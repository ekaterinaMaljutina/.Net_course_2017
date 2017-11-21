using MiniRoguelike.Exception;
using MiniRoguelike.GameMap;

namespace MiniRoguelike.Player
{
    public class Hero
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public readonly WorldMap Map;

        public Hero(WorldMap map)
        {
            Map = map;
            InitFirstPosition();
        }

        public void InitFirstPosition()
        {
            var position = Map.GetFirstEmptyPosition();
            if (position.Item1 == -1 && position.Item2 == -1)
            {
                throw new PlayerPositionException("Empty position is not found");
            }
            X = position.Item1;
            Y = position.Item2;
        }

        public void MoveLevt()
        {
            UpdatePosotion(X, Y - 1);
        }

        public void MoveRight()
        {
            UpdatePosotion(X, Y + 1);
        }

        public void MoveUp()
        {
            UpdatePosotion(X - 1, Y);
        }

        public void MoveDown()
        {
            UpdatePosotion(X + 1, Y);
        }


        private void UpdatePosotion(int x, int y)
        {
            if (!Map.IsEmptyCell(x, y)) return;
            X = x;
            Y = y;
        }
    }
}