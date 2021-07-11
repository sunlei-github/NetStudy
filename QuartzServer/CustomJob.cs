using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzServer
{
    /// <summary>
    ///创建一个自定义的任务
    /// </summary>
    [PersistJobDataAfterExecution]  //保留JobDataMap中更新的结果的值 使用Put去更新每次计算结果后的值
    [DisallowConcurrentExecution]   //保证一个任务运行完毕之后 再去进行另一个任务
    public class CustomJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("--------------------------------------------------------------------");
                #region JobDataMap
                var jobValue = context.JobDetail.JobDataMap.Get("jobKey");
                Console.WriteLine($"jobKey的值是{jobValue}");
                var jobInvokeCount = Convert.ToInt32(context.JobDetail.JobDataMap.Get("invokeCount"));
                Console.WriteLine($"执行的次数{jobInvokeCount}");
                context.JobDetail.JobDataMap.Put("invokeCount", ++jobInvokeCount);

                var triggerValue = context.Trigger.JobDataMap.Get("trigger");
                Console.WriteLine($"触发器中的值{triggerValue}"); 
                #endregion
                Console.WriteLine($"当前时间是{DateTime.Now:hh:mm:ss}");
                Console.WriteLine("--------------------------------------------------------------------");
            });
        }
    }
}
