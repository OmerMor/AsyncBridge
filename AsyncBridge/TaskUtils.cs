using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBridge
{
    public class TaskUtils
    {
        public static Task Delay(int millis)
        {
            // There isn't a non-generic version of this. We should have a unit type
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            Timer timer = new Timer(_ => taskCompletionSource.SetResult(null), null, millis, Timeout.Infinite);

            return taskCompletionSource.Task;
        }
    }
}
