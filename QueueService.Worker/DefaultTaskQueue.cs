using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueService.Worker
{
    public class DefaultTaskQueue : ITaskQueue
    {

        public DefaultTaskQueue()
        {

        }

        public ValueTask DequeueTaskAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public ValueTask QueueTaskAsync(Func<ValueTask, CancellationToken> task)
        {
            throw new NotImplementedException();
        }
    }
}
