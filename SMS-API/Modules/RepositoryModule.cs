using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.Reflection;
using SMS.Api.Domain;

namespace SMS.Api.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(RepositoryModule)
            .GetTypeInfo()
            .Assembly;

        builder.RegisterAssemblyTypes(assembly)
            .Where(x => x.IsAssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
}