using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace wsService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceHost =>
            {
                serviceHost.Service<Service>(config =>
                    {
                        config.ConstructUsing(() => new Service());
                        config.WhenStarted(svc => svc.Start());
                        config.WhenStopped(svc => svc.Stop());
                    }
                );

                serviceHost.StartAutomatically();
                serviceHost.SetDescription("Test Windows Service");
                serviceHost.SetDisplayName("Test Windows Service Feature1");
                serviceHost.SetServiceName("testWsService");
            });
        }
    }
}
