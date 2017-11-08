using System;
using System.Threading;

namespace ArrayQueue
{
    public class QueueLockBase<TR> : IArrayQueue<TR>
    {
        private readonly int _maxSize;
        private readonly TR[] _queue;

        private int _size;
        private int _ptrHead;
        private int _ptrTail;

        private readonly object _lockObj;

        public QueueLockBase(int maxSize)
        {
            if (maxSize < 0)
            {
                throw new ArgumentException($" max size must be > 0, but get {maxSize}");
            }
            _maxSize = maxSize;
            _lockObj = new object();
            _queue = new TR[_maxSize];
            _ptrHead = _ptrTail = _size = 0;
        }

        public void Enqueue(TR value)
        {
            lock (_lockObj)
            {
                while (_size >= _maxSize)
                {
                    Monitor.Wait(_lockObj);
                }
                _Enqueue(value);
                Monitor.PulseAll(_lockObj);
            }
        }

        public TR Dequeue()
        {
            lock (_lockObj)
            {
                while (_size == 0)
                {
                    Monitor.Wait(_lockObj);
                }
                var value = _Dequeue();
                Monitor.PulseAll(_lockObj);
                return value;
            }
        }

        public bool TryEnqueue(TR value)
        {
            lock (_lockObj)
            {
                if (_size >= _maxSize) return false;
                
                _Enqueue(value);
                return true;
            }
        }

        public bool TryDequeue(ref TR value)
        {
            lock (_lockObj)
            {
                if (_size <= 0) return false;
                
                value = _Dequeue();
                return true;
            }
        }

        public void Clear()
        {
            lock (_lockObj)
            {
                _size = _ptrHead = _ptrTail = 0;
            }
        }

        private void _Enqueue(TR value)
        {
            _size++;
            _queue[_ptrTail] = value;
            _ptrTail = (_ptrTail + 1) % _maxSize;
        }

        private TR _Dequeue()
        {
            _size--;
            var value = _queue[_ptrHead];
            _ptrHead = (_ptrHead + 1) % _maxSize;
            return value;
        }
    }
}