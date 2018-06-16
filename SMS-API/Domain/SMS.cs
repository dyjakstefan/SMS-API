using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{

    /// <summary>
    /// SMS model.
    /// </summary>
    public class SMS
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
        /// <summary>
        /// Data when object was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Date when sms should be send.
        /// </summary>
        public DateTime SendAt { get; set; }

        /// <summary>
        /// Protected constructor.
        /// </summary>
        protected SMS()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smsId">Id of sms.</param>
        /// <param name="message">Text message.</param>
        /// <param name="phoneNumber">Recipient's phone number.</param>
        /// <param name="sendAt">Date when sms should be send.</param>
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
