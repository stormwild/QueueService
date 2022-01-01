using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueService.Worker
{
    public interface ITaskQueue
    {
        ValueTask QueueTaskAsync(Func<ValueTask, CancellationToken> task);
        ValueTask DequeueTaskAsync(CancellationToken token);
    }
}
