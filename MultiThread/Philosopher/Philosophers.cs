using System.Collections.Generic;
using System.Threading;

namespace Philosopher
{
    public sealed class Fork
    {
        public readonly int Id;

        public Fork(int id)
        {
            Id = id;
        }
    }
    
    public class Philosophers
    {
        private readonly int _id;
        private readonly Fork _left;
        private readonly Fork _right;

        private Philosophers(int id, Fork left, Fork right)
        {
            _id = id;
            _left = left;
            _right = right;
        }

        private void TryToEat()
        {

            lock (_left)
            {
                lock (_right)
                {
                    System.Console.WriteLine($"Philisopher {_id} is eating fork: {_left.Id} and {_right.Id} ");
                    Thread.Sleep(500);
                    System.Console.WriteLine($"Philisopher {_id} is return fork: {_left.Id} and {_right.Id}");
                }
            }
        }

        private void Dinner()
        {
            while (true)
            {
                TryToEat();
                Thread.Yield();
            }
        }

        public static void Main()
        {
            const int countThread = 5;
            var fork = new List<Fork>();
            var philosophers = new List<Philosophers>();
            for (var i = 0; i < countThread; i++)
            {
                fork.Add(new Fork(i));
            }
            for (var i = 0; i < countThread; i++)
            {
                philosophers.Add(new Philosophers(i, fork[i], fork[(i + 1) % (countThread - 1)]));
            }
            var threads = new List<Thread>();
            philosophers.ForEach(philosopher => threads.Add(new Thread(philosopher.Dinner)));
            
            threads.ForEach(thread => thread.Start());
            Thread.Sleep(10000);
            threads.ForEach(thread => thread.Abort());
        }
    }
}