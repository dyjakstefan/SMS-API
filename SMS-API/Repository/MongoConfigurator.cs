using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    /// <summary>
    /// Configuration for Mongo Database.
    /// </summary>
    public class MongoConfigurator
    {
        private static bool _initialized;

        /// <summary>
        /// Initialize connection with database.
        /// </summary>
        public static void Initialize()
        {
            if(_initialized)
            {
                return;
            }
            _initialized = true;
        }

        /// <summary>
        /// Register convention for database.
        /// </summary>
        private static void RegisterConvention()
        {
            ConventionRegistry.Register("SMSConvention", new MongoConvention(), x => true);
        }

        /// <summary>
        /// Class that holds convention for database.
        /// </summary>
        private class MongoConvention: IConventionPack
        {
            /// <summary>
            /// Conventions for database.
            /// </summary>
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}
