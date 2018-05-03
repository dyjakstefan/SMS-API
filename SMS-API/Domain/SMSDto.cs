using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class SMSDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
    }
}
