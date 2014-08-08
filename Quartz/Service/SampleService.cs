using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Quartz;
using Quartz.Impl.Calendar;

namespace Service
{
    public class SampleService
    {
        private readonly ISchedulerFactory _factory;
        private IScheduler _scheduler;

        public SampleService(ISchedulerFactory factory)
        {
            _factory = factory;
            _scheduler = _factory.GetScheduler();
        }

        public void Start()
        {
            TestLog("Uruchomienie usługi");
            _scheduler.Start();

            //IJobDetail job = JobBuilder.Create<HelloWorldJob>()
            //        .WithIdentity("HelloWorld", "Basic")
            //        .UsingJobData("Version", "1")
            //        .Build();

            //var cal = new DailyCalendar("10:00", "12:00");
            //_scheduler.AddCalendar("test", cal, true, true);

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("s10", "Seconds")
            //    .StartNow()
            //    .WithSimpleSchedule(x =>
            //        x.WithIntervalInSeconds(10)
            //        .RepeatForever())
            //    .Build();

            //_scheduler.ScheduleJob(job, trigger); 
        }

        public void Stop()
        {
            TestLog("Wyłączenie usługi");
            _scheduler.Shutdown();
        }

        private void TestLog(string str)
        {
            using (var sw = new StreamWriter(@"C:\Users\ejuchnikowski\Source\Repos\Samples3\Quartz\Service\bin\Debug\logi.txt", true))
            {
                sw.WriteLine(string.Format("{0} : {1}", str, DateTime.Now.ToString()));
            }
        }
    }
}
