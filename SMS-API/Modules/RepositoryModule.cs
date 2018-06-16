using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.Reflection;
using SMS.Api.Domain;

namespace SMS.Api.Modules
{
    /// <summary>
    /// Module for repository components.
    /// </summary>
    public class RepositoryModule : Autofac.Module
    {
        /// <summary>
        /// Register repositories. 
        /// </summary>
        /// <param name="builder">Container for modules</param>
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