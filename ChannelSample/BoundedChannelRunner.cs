using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelSample
{
    internal class BoundedChannelRunner : IChannelRunner
    {
        private readonly Channel<int> _boundedChannel;
        private readonly int _writeDelay;
        private readonly int _readDelay;

        public BoundedChannelRunner(int writeDelay = 1000, int readDelay = 1000)
        {
            _writeDelay = writeDelay;
            _readDelay = readDelay;
            _boundedChannel = Channel.CreateBounded<int>(1);
        }

        public async Task RunAsync()
        {
            _ = Task.Run(async () =>
            {
                for (int i = 0; ; i++)
                {
                    await Task.Delay(_writeDelay);

                    await _boundedChannel.Writer.WriteAsync(i); // Waits for space to be available
                }
            });

            //while (true)
            //{
            //    await Task.Delay(_readDelay);

            //    Console.WriteLine(await _boundedChannel.Reader.ReadAsync());
            //}

            // Alternative way of iterating all items in a Channel
            await foreach (var item in _boundedChannel.Reader.ReadAllAsync())
            {
                await Task.Delay(_readDelay); // 2s
                Console.WriteLine(item);
            }
        }
    }
}
