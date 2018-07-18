using System.Timers;
using System.Threading.Tasks;

namespace Common
{
    public static class TaskHelpers
    {
        public static Task DelayLoad(this Task task)
        {
            var tcs = new TaskCompletionSource<ElapsedEventHandler>();

            Timer timer = new Timer();
            timer.Elapsed += ((o,e) => Task.Delay(5000));

            tcs.Task.ContinueWith(t => { timer.Dispose(); });

            return tcs.Task;
        }
    }
}
