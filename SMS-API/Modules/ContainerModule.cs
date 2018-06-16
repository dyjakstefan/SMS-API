using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace SMS.Api.Modules
{
    /// <summary>
    /// This class register all components.
    /// </summary>
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Register all modules in builder.
        /// </summary>
        /// <param name="builder">Container for modules</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}