using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MongoDB.Driver;
using SMS.Api.Domain;

namespace SMS.Api.Modules
{
    /// <summary>
    /// Module for Mongo Database component.
    /// </summary>
    public class MongoModule : Autofac.Module
    {
        /// <summary>
        /// Register client for Mongo Database and load settings for Mongo.
        /// </summary>
        /// <param name="builder">Container for modules</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) =>
            {
                var settings = c.Resolve<MongoSettings>();

                return new MongoClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((c, p) =>
            {
                var mongoClient = c.Resolve<MongoClient>();
                var settings = c.Resolve<MongoSettings>();
                var database = mongoClient.GetDatabase(settings.Database);

                return database;
            }).As<IMongoDatabase>();

            var assembly = typeof(MongoModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IMongoRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
