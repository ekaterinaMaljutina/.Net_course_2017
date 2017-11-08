using System;
using System.Threading;
using ArrayQueue;
using NUnit.Framework;

namespace ArrayQueueTest
{
    [TestFixture]
    public class QueueTest
    {
        private const int Size = 10;
        private readonly IArrayQueue<int> _queueLockBase = new QueueLockBase<int>(Size);
        private readonly IArrayQueue<int> _queueLockFree = new QueueLockFree<int>(Size);

        [Test]
        public void LockFreeEnqueueTest()
        {
            CheckEnqueue(_queueLockFree);
        }

        [Test]
        public void BaseLockEnqueueTest()
        {
            CheckEnqueue(_queueLockBase);
        }


        [Test]
        public void BaseLockDequeueTest()
        {
            CheckEnqueue(_queueLockBase);
            CheckDequeue(_queueLockBase);
        }

        [Test]
        public void FreeLockDequeueTest()
        {
            CheckEnqueue(_queueLockFree);
            CheckDequeue(_queueLockFree);
        }


        [Test]
        public void BaseLockClearTest()
        {
            CheckClearTest(_queueLockBase);
        }
        
        [Test]
        public void FreeLockClearTest()
        {
            CheckClearTest(_queueLockFree);
        }
        
        private static void CheckClearTest(IArrayQueue<int> queue)
        {
            CheckEnqueue(queue);
            queue.Clear();
            var check = 0;
            Assert.False(queue.TryDequeue(ref check));
        }
        
        private static void CheckEnqueue(IArrayQueue<int> queue)
        {
            for (var i = 0; i < Size; i++)
            {
                queue.Enqueue(i);
            }
            Assert.False(queue.TryEnqueue(1111));
        }

        private static void CheckDequeue(IArrayQueue<int> queue)
        {
            for (var i = 0; i < Size; i++)
            {
                Assert.AreEqual(queue.Dequeue(), i);
            }
        }
    }
}
