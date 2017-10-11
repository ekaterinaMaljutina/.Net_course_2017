using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MiniRoguelike.GameMap
{
    public class WorldMap
    {
        private static readonly string PATH_TO_MAP = @"../../GameMap/Map.txt";

        public readonly int Width;
        public readonly int Height;

        private readonly string[] _map;

        public List<Tuple<int, int, char>> Map { get; }

        public WorldMap()
        {
            Map = new List<Tuple<int, int, char>>();
            _map = File.ReadLines(@PATH_TO_MAP).ToArray();
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
            Map.Where(tuple => tuple.Item1 == x && tuple.Item2 == y).First().Item3 == CellType.EMPTY_CELL;
        }


        public Tuple<int, int> GetFirstEmptyPosition()
        {
            var emptyCell = GetEmptyCells();
            if (emptyCell.Count == 0)
            {
                return new Tuple<int, int>(-1, -1);
            }
                
            return emptyCell.First();
        }

        public List<Tuple<int, int>> GetEmptyCells()
        {
            return Map.Where(tuple => tuple.Item3 == CellType.EMPTY_CELL)
                .Select(tuple => new Tuple<int, int>(tuple.Item1, tuple.Item2)).ToList();             
        }

        private bool CheckValidMap()
        {
            return _map.Length != 0 && _map[0].Length != 0 &&
            _map.All(line => line.All(charValue => 
                    charValue == CellType.EMPTY_CELL || charValue == CellType.BUSY_CELL)
                && line.Length == _map[0].Length);
        }


        private void GetCells()
        {           
            for (var i = 0; i < Height; ++i)
            {
                for (var j = 0; j < Width; ++j)
                {               
                    Map.Add(new Tuple<int, int, char>(i, j, _map[i][j]));
                }
            } 
        }
    }

    public class MapReadException : Exception
    {
        public MapReadException(string message)
            : base(message)
        {
        }
            
    }
}

