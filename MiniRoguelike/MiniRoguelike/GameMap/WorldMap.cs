using System.IO;
using System.Linq;
using System.Collections.Generic;
using MiniRoguelike.Exception;

namespace MiniRoguelike.GameMap
{
    public class WorldMap
    {
        private const string PathToMap = @"../../GameMap/Map.txt";

        public int Width;
        public int Height;

        private string[] _map;

        public List<(int, int, char)> Map { get; set; }

        public WorldMap()
        {
            Init(File.ReadLines(PathToMap).ToArray());
        }

        public WorldMap(string[] map)
        {
            Init(map);
        }

        public void Init(string[] map)
        {
            Map = new List<(int, int, char)>();
            _map = map;
            if (!CheckValidMap())
            {
                throw new MapReadException("map is mot valid");
            }
            Height = _map.Length;
            Width = _map[0].Length;
            GetCells();
        }

        public bool IsEmptyCell(int x, int y)
        {
            return x < Width && x >= 0 && y < Height && y >= 0 &&
                   Map.First(tuple => tuple.Item1 == x && tuple.Item2 == y).Item3 == CellType.EmptyCell;
        }


        public (int, int) GetFirstEmptyPosition()
        {
            var emptyCell = GetEmptyCells();
            return emptyCell.Count == 0 ? (-1, -1) : emptyCell.First();
        }

        public List<(int, int)> GetEmptyCells()
        {
            return Map.Where(tuple => tuple.Item3 == CellType.EmptyCell)
                .Select(tuple => (tuple.Item1, tuple.Item2)).ToList();
        }

        private bool CheckValidMap()
        {
            return _map.Length != 0 && _map[0].Length != 0 &&
                   _map.All(line => line.All(charValue =>
                                        charValue == CellType.EmptyCell || charValue == CellType.BusyCell)
                                    && line.Length == _map[0].Length);
        }

        private void GetCells()
        {
            for (var i = 0; i < Height; ++i)
            {
                for (var j = 0; j < Width; ++j)
                {
                    Map.Add((i, j, _map[i][j]));
                }
            }
        }
    }
}