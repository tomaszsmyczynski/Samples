using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Ninject;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
                {
                    x.UseNLog();

                    x.UseNinject(new SampleNinjectModule());

                    x.Service<SampleService>(s =>
                        {
                            s.ConstructUsingNinject(); 
     
                            s.WhenStarted(tc => tc.Start());              
                            s.WhenStopped(tc => tc.Stop()); 
                        });

                    x.RunAs(@"xpl\ejuchnikowski", "Emil20011991");

                    x.SetDescription("Opis testowego serwisu");        
                    x.SetDisplayName("TestowySerwis");                       
                    x.SetServiceName("TestowySerwis");
                });
        }
    }
}
