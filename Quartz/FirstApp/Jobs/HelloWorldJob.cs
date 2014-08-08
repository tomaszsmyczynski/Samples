using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Jobs
{
    public class HelloWorldJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            TestLog("Hello word!");
        }

        private void TestLog(string str)
        {
            using (var sw = new StreamWriter(@"C:\Users\ejuchnikowski\Source\Repos\Samples3\Quartz\Service\bin\Debug\logi2.txt", true))
            {
                sw.WriteLine(string.Format("{0} : {1}", str, DateTime.Now.ToString()));
            }
        }
    }
}
