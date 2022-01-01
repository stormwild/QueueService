using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelSample
{
    internal class SimpleChannelRunner : IChannelRunner
    {
        private readonly SimpleChannel<int> _channel;
        private readonly int _writeDelay;
        private readonly int _readDelay;

        public SimpleChannelRunner(int writeDelay = 1000, int readDelay = 1000)
        {
            _writeDelay = writeDelay;
            _readDelay = readDelay;
            _channel = new SimpleChannel<int>();
        }

        public async Task RunAsync()
        {
            _ = Task.Run(async () =>
            {
                for (int i = 0; ; i++)
                {
                    await Task.Delay(_writeDelay);

                    _channel.Write(i);
                }
            });

            while (true)
            {
                await Task.Delay(_readDelay);

                Console.WriteLine(await _channel.ReadAsync());
            }
        }
    }
}
