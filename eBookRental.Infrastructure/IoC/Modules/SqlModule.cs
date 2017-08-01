using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using System.Reflection;
using eBookRental.Infrastructure.Entities;

namespace eBookRental.Infrastructure.IoC.Modules
{
    public class SqlModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(SqlModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<ISqlRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
