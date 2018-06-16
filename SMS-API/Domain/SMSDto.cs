using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    /// <summary>
    /// Data transfer object for SMS
    /// </summary>
    public class SMSDto
    {
        /// <summary>
        /// Id of sms.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Text message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Recipient's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
