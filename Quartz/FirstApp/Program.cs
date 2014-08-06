using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using System.Threading;
using FirstApp.Jobs;
using Quartz.Impl.Calendar;
using System.Collections.Specialized;
using System.Configuration;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NameValueCollection quartzSection = (NameValueCollection)ConfigurationManager.GetSection("quartz");

                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };

                ISchedulerFactory factory = new StdSchedulerFactory(quartzSection);

                IScheduler scheduler = factory.GetScheduler();

                scheduler.Start();

                IJobDetail job = JobBuilder.Create<HelloWorldJob>()
                    .WithIdentity("HelloWorld", "Basic")
                    .UsingJobData("Version", "1")
                    .Build();

                var cal = new DailyCalendar("10:00", "12:00");
                scheduler.AddCalendar("test", cal, true, true);

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("s10", "Seconds")
                    .StartNow()
                    .WithSimpleSchedule(x =>
                        x.WithIntervalInSeconds(10)
                        .RepeatForever())
                    .Build();

                scheduler.ScheduleJob(job, trigger);                        

                Thread.Sleep(TimeSpan.FromSeconds(60));

                scheduler.Shutdown();
            }
            catch (SchedulerException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
