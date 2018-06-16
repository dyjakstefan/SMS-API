using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using SMS.Api.Domain;

namespace SMS.Api.Modules
{
    /// <summary>
    /// Module for settings component.
    /// </summary>
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Register settings.
        /// </summary>
        /// <param name="builder">Container for modules</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                .SingleInstance();
        }
    }
}
