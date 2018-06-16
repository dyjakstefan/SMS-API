using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    /// <summary>
    /// Class for database settings 
    /// </summary>
    public class MongoSettings
    {
        /// <summary>
        /// Connection to database.
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Name of database.
        /// </summary>
        public string Database { get; set; }

    }
}
