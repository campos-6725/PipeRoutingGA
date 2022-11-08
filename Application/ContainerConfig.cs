using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Entities;
using EntitiesInterfaces;
using QuikGraph;
using Services;
using Services.Interfaces;

namespace Application
{
    class ContainerConfig
    {

        internal static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Driver>()
                .As<IDriver>();

            //declarar implementacoes aqui

            builder.RegisterType<GraphRepository>()
                .As<IRepository<BidirectionalGraph<Node, Edge>>>();




            return builder.Build();
        }

    }
}
