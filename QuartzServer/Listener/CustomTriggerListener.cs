using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzServer.Listener
{
    public class CustomTriggerListener : ITriggerListener
    {
        public string Name =>"触发器监听";

        public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("TriggerComplete");
            });
        }

        public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("TriggerFired");
            });
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("TriggerMisfired");
            });
        }

        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult<bool>(false);  //返回true则否决任务执行
        }
    }
}
