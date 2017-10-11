using System;

namespace MiniRoguelike
{
    public class EventLoop
    {
        public event Action LeftHandler;
        public event Action RightHandler;
        public event Action UpHandler;
        public event Action DownHandler;
        public event Action ShutDown;

        public void Run()
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler?.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler?.Invoke();
                        break;
                    case ConsoleKey.UpArrow:
                        UpHandler?.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler?.Invoke();
                        break;
                    case ConsoleKey.Enter:
                        ShutDown?.Invoke();
                        break;

                }
            }
        }
    }
}

