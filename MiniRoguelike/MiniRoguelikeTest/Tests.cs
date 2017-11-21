using System;
using MiniRoguelike;
using MiniRoguelike.Exception;
using MiniRoguelike.GameMap;
using NUnit.Framework;
using MiniRoguelike.Player;

namespace MiniRoguelikeTest
{
    public class Tests
    {
        [Test]
        public void MoveTest()
        {
            
            string[] mapArray =
            {
                "###",
                "#.#",
                "###"
            };
            var map = new WorldMap(mapArray);
            var hero = new Hero(map);
            var world = new DrawWorld(map, hero);
            
            var x = hero.X;
            var y = hero.Y;
            world.Left();
            Assert.AreEqual(x, hero.X);
            Assert.AreEqual(y, hero.Y);
            world.Right();
            Assert.AreEqual(x, hero.X);
            Assert.AreEqual(y, hero.Y);
            world.Up();
            Assert.AreEqual(x, hero.X);
            Assert.AreEqual(y, hero.Y);
            world.Down();
            Assert.AreEqual(x, hero.X);
            Assert.AreEqual(y, hero.Y);
        }

        [Test]
        public void WrongMapTest()
        {
            string[] map =
            {
                "###",
                "#."
            };
            Exception ex = Assert.Throws<MapReadException>(() => new WorldMap(map));
            Assert.AreEqual("map is mot valid", ex.Message);
        }

        [Test]
        public void WrongPlayerTest()
        {
            string[] map =
            {
                "##",
                "##"
            };
            var world = new WorldMap(map);
            Exception ex = Assert.Throws<PlayerPositionException>(() => new Hero(world));
            Assert.AreEqual("Empty position is not found", ex.Message);
        }
    }
}