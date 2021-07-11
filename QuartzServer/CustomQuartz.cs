using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using QuartzServer.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzServer
{
    /// 三大核心对象
    ///     IScheduler：时间轴  单元  盒子  在这里进行任务配置
    ///     IJobDetail：描述具体做什么事情，定时任务执行的动作
    ///     ITrigger：时间策略，按照什么频率来执行
    public class CustomQuartz
    {
        public async static Task Init()
        {
            #region 查看系统日志
            LogProvider.SetCurrentLogProvider(new CustomConsoleLogProvider());
            #endregion

            #region 创建一个任务调度器
            StdSchedulerFactory _stdSchedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await _stdSchedulerFactory.GetScheduler();
            #endregion

            #region 构建一个任务
            IJobDetail jobDetail = JobBuilder.Create<CustomJob>()
                            .WithIdentity("jobGroupName", "jobTestGroup")
                            .WithDescription("这是一个测试任务")
                            .Build();

            //任务运行过程中需要的参数
            jobDetail.JobDataMap.Add("jobKey", "AAA");  //添加相同的key会报错
            jobDetail.JobDataMap.Add("invokeCount", 0);
            #endregion

            #region 构建一个任务的定时器
            //使用corn表达式的构建定时器
            ITrigger trigger = TriggerBuilder.Create()
                .WithDescription("一个测试的任务定时器")
                .WithIdentity("triggerGroupName", "triggerTestGroup")
                .WithCronSchedule("0/5 * * * * ? ")   //每30秒执行一次
                .StartNow()
                .Build();

            //使用WithSimpleSchedule 对象构建定时器
            //ITrigger trigger = TriggerBuilder.Create()
            //        .WithDescription("一个测试的任务定时器")
            //        .WithIdentity("triggerGroupName", "triggerTestGroup")
            //        .WithSimpleSchedule(c =>
            //        {
            //            c.WithIntervalInSeconds(5); //每5秒执行一次
            //            //c.WithIntervalInMinutes(1);
            //            //c.WithIntervalInHours(1);
            //            c.RepeatForever();
            //        })  
            //        .StartNow()
            //        .Build();

            trigger.JobDataMap.Add("trigger", "triggervalue");
            #endregion

            #region 添加监视器
            scheduler.ListenerManager.AddJobListener(new CustomJobListener());
            scheduler.ListenerManager.AddTriggerListener(new CustomTriggerListener());
            scheduler.ListenerManager.AddSchedulerListener(new CustomSchedulerListener());
            #endregion

            await scheduler.Start();  //调度器开始运行
            await scheduler.ScheduleJob(jobDetail, trigger);  //调度器开始执行任务
        }
    }
}
