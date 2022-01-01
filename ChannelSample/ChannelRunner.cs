using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelSample
{
    internal class ChannelRunner : IChannelRunner
    {
        private readonly Channel<int> _channel;
        private readonly int _writeDelay;
        private readonly int _readDelay;

        public ChannelRunner(int writeDelay = 1000, int readDelay = 1000)
        {
            _writeDelay = writeDelay;
            _readDelay = readDelay;
            _channel = Channel.CreateUnbounded<int>();
        }

        public async Task RunAsync()
        {
            _ = Task.Run(async () =>
            {
                for (int i = 0; ; i++)
                {
                    await Task.Delay(_writeDelay);

                    _channel.Writer.TryWrite(i);
                }
            });

            while (true)
            {
                await Task.Delay(_readDelay);

                Console.WriteLine(await _channel.Reader.ReadAsync());
            }
        }
    }
}
