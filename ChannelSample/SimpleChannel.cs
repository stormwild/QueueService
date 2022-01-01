using System.Collections.Concurrent;

namespace ChannelSample
{
    public class SimpleChannel<T>
    {
        private readonly ConcurrentQueue<T> _queue = new();
        private readonly SemaphoreSlim _sem = new(0);

        public void Write(T item)
        {
            _queue.Enqueue(item);
            _sem.Release();
        }

        // This creates a task everytime
        // Better implementation would be to return a ValueTask
        public async Task<T> ReadAsync()
        {
            await _sem.WaitAsync();
            _queue.TryDequeue(out T item);
            return item;
        }
    }
}
