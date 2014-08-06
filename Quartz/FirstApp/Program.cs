using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using System.Threading;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };

                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                
                scheduler.Start();

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
