using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Application
{
    class ContainerConfig
    {

        internal static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //declarar implementacoes aqui






            return builder.Build();
        }

    }
}
