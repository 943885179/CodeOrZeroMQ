using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 翻转图像
{

    /// <summary>
    /// 定时调度 ：处理一般定时任务 Timer，复杂的需要第三方框架
    /// 五大构建：
    /// 1.  调度器：Scheduler
    /// 2.  作业任务：Job
    /// 3.  触发器： Trigger
    /// 4.  线程池： SimpleThreadPool(通过调度器配置)
    /// 5.  作业持久化：JobStore （通过调度器配置）
    ///  步骤：  
    /// 创建调度实例 Scheduler
    /// 继承 IJob 接口，实现具体任务逻辑    
    /// 创建触发器实例 Trigger
    /// 把job、trigger加入调度器（其中job是jobdetail工作实例）    
    /// 启动调度器 Start# 任务的开启、关闭、暂停通过 调度器（Scheduler）相关方法操作# 每个实例的创建不止一种方法，具体查阅详情# Job和触发器的关系：1对1、多对1# quartz.net的持久化，是把job、trigger一些信息存储到数据库里面，以解决内存存储重启丢失。# 项目中使用的时候， 一般单独封装 scheduler、job、trigger
    /// author:mzj
    /// </summary>
    public class QuartzHelp
    { // 创建调度器
        private static IScheduler scheduler;
        // <summary>
        /// 任务工厂
        /// </summary>
        /// <typeparam name="T">工作类</typeparam>
        /// <param name="DetailName">工作名称</param>
        /// <param name="TriggerName">触发器名称</param>
        /// <param name="Minute">多长时间出发一次</param>
        public static async void JobsFactory<T>(string DetailName, string TriggerName, int Minute)
            where T : IJob
        {
            // 创建工厂
            ISchedulerFactory factory = new StdSchedulerFactory();
            // 创建调度器
            scheduler = await factory.GetScheduler();
            // 启动
            await scheduler.Start();
            // 描述工作
            var jobDetail = new JobDetailImpl(DetailName, null, typeof(T));
            //触发器
            ISimpleTrigger trigger = new SimpleTriggerImpl(TriggerName,
                null,
                DateTime.Now,
                null,
                SimpleTriggerImpl.RepeatIndefinitely,
                TimeSpan.FromSeconds(Minute));
            //执行
            await scheduler.ScheduleJob(jobDetail, trigger);
        }

        // <summary>
        /// 任务工厂
        /// </summary>
        /// <typeparam name="T">工作类</typeparam>
        /// <param name="DetailName">工作名称</param>
        /// <param name="TriggerName">触发器名称</param>
        /// <param name="Minute">多长秒触发一次</param>
        /// <param name="Group">组别</param>
        public static async void JobFactory<T>(string DetailName, string TriggerName, int Minute,string GroupName="Group")
           where T : IJob
        {
            // 创建调度器
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            // 启动
            await scheduler.Start();
            // 描述工作
            var jobDetail = new JobDetailImpl(DetailName, GroupName, typeof(T));
            // var jobDetails = JobBuilder.Create<T>().WithIdentity(DetailName,GroupName).Build();
            //触发器
            ISimpleTrigger trigger = new SimpleTriggerImpl(TriggerName,
                GroupName,
                DateTime.Now,
                null,
                SimpleTriggerImpl.RepeatIndefinitely,
                TimeSpan.FromSeconds(Minute));
           // var triggers = TriggerBuilder.Create().WithIdentity(TriggerName, GroupName).WithCronSchedule("00 15 10 * *?*").Build();
            //执行
            await scheduler.ScheduleJob(jobDetail, trigger);
        }
        /// <summary>
        /// Cron表达式执行定时任务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DetailName"></param>
        /// <param name="TriggerName"></param>
        /// <param name="cron"></param>
        /// <param name="GroupName"></param>
        public static async void JobFactoryByCron<T>(string DetailName, string TriggerName, string cron, string GroupName = "")
          where T : IJob
        {
            // 启动
            await scheduler.Start();
            // 描述工作
            var jobDetail = JobBuilder.Create<T>().WithIdentity(DetailName,GroupName).Build();
            //触发器
            var trigger = TriggerBuilder.Create().WithIdentity(TriggerName, GroupName)
                .WithCronSchedule(cron)
                .Build();
            //执行
            await scheduler.ScheduleJob(jobDetail, trigger);
        }
        /// <summary>
        /// 停止调度
        /// </summary>
        public static async void Shutdown() {
            if (scheduler!=null)
            {
                await scheduler.Shutdown();
            }
        }
    }
}
