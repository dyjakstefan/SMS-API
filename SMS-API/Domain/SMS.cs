using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class SMS
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime SendAt { get; set; }

        protected SMS()
        {
        }

        public SMS(Guid smsId, string message, string phoneNumber, DateTime sendAt)
        {
            Id = smsId;
            Message = message;
            PhoneNumber = phoneNumber;
            SendAt = sendAt;
            CreatedAt = DateTime.UtcNow;
        }

    }
}
