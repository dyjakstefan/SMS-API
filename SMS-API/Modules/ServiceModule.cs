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
    /// Module for service components.
    /// </summary>
    public class ServiceModule : Autofac.Module
    {
        /// <summary>
        /// Register services. 
        /// </summary>
        /// <param name="builder">Container for modules</param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}