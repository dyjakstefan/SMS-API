using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class MongoConfigurator
    {
        private static bool _initialized;

        public static void Initialize()
        {
            if(_initialized)
            {
                return;
            }
            _initialized = true;
        }

        private static void RegisterConvention()
        {
            ConventionRegistry.Register("SMSConvention", new MongoConvention(), x => true);
        }

        private class MongoConvention: IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}
