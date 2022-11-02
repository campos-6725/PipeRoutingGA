using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using EntitiesInterfaces;

namespace Application
{
    class ContainerConfig
    {

        internal static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Driver>().As<IDriver>();

            //declarar implementacoes aqui






            return builder.Build();
        }

    }
}
