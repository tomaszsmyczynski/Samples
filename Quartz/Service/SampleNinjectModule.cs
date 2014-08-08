using Ninject.Modules;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SampleNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISchedulerFactory>().To<StdSchedulerFactory>()
                .WithConstructorArgument("props", (NameValueCollection)ConfigurationManager.GetSection("quartz"));
        }
    }
}
