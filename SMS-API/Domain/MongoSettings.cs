﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }

        public MongoSettings()
        {
            ConnectionString = "mongodb://localhost:27017";
            Database = "SMS";
        }
    }
}