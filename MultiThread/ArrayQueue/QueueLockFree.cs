using System;
using System.Threading;

namespace ArrayQueue
{
    public class QueueLockFree<TR> : IArrayQueue<TR>
    {
        private readonly int _maxSize;
        private readonly TR[] _queue;

        private long _ptrHead;
        private long _ptrTail;

        public QueueLockFree(int maxSize)
        {
            if (maxSize < 0)
            {
                throw new ArgumentException($" max size must be > 0, but get {maxSize}");
            }

            _maxSize = maxSize;
            _ptrHead = _ptrTail = 0;
            _queue = new TR[_maxSize];
        }

        public void Enqueue(TR value)
        {
            while (!TryEnqueue(value))
            {
                Thread.Yield();
            }
        }

        public TR Dequeue()
        {
            var value = default(TR);
            while (!TryDequeue(ref value))
            {
                Thread.Yield();
            }
            return value;
        }

        public bool TryEnqueue(TR value)
        {
            long tail;
            do
            {
                var head = Interlocked.Read(ref _ptrHead);
                tail = Interlocked.Read(ref _ptrTail);

                if (tail + 1 - head > _maxSize)
                {
                    return false;
                }
            } while (Interlocked.CompareExchange(ref _ptrTail, tail + 1, tail) != tail);
            _queue[tail % _maxSize] = value;
            return true;
        }

        public bool TryDequeue(ref TR value)
        {
            long head;
            do
            {
                head = Interlocked.Read(ref _ptrHead);
                var tail = Interlocked.Read(ref _ptrTail);

                if (tail - head <= 0)
                {
                    return false;
                }
            } while (Interlocked.CompareExchange(ref _ptrHead, head + 1, head) != head);
            value = _queue[head % _maxSize];
            return true;
        }

        public void Clear()
        {
            while (true)
            {
                var head = Interlocked.Read(ref _ptrHead);
                var tail = Interlocked.Read(ref _ptrTail);
                if (head == Interlocked.CompareExchange(ref _ptrHead, 0, head) &&
                    tail == Interlocked.CompareExchange(ref _ptrTail, 0, tail)) return;
                Interlocked.CompareExchange(ref _ptrHead, head, 0);
                Interlocked.CompareExchange(ref _ptrTail, tail, 0);
            }
        }
    }
}