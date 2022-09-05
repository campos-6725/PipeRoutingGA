using System;
using Autofac;
using Definitions;
using EntitiesInterfaces;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = ContainerConfig.Configure();

            using (var programScope = container.BeginLifetimeScope())
            {
                var driver = programScope.Resolve<IDriver>();

                Result result = driver.Execute();
            }

        }
    }
}
