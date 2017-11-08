namespace ArrayQueue
{
    public interface IArrayQueue<TR>
    {
        void Enqueue(TR value);
        TR Dequeue();
        bool TryEnqueue(TR value);
        bool TryDequeue(ref TR value);
        void Clear();
    }
}