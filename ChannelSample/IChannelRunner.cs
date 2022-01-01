using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelSample
{
    internal interface IChannelRunner
    {
        public Task RunAsync();
    }
}
