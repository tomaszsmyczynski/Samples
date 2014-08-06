using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Jobs
{
    public class HelloWorldJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.JobDetail.JobDataMap;

            var version = dataMap.GetFloat("Version");

            Console.WriteLine("Hello world! Version: {0}, Key: {1}", version, key);
        }
    }
}
