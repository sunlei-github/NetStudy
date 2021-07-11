using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzServer.Listener
{
    public class CustomJobListener : IJobListener
    {
        public string Name => "任务监听";

        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("任务取消时执行");
            });
        }

        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("定时任务执行前执行");
            });
        }

        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("定时任务执后前执行");
            });
        }
    }
}
