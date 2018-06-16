using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    /// <summary>
    /// Interface for SMSService 
    /// </summary>
    public interface ISMSService : IService
    {
        /// <summary>
        /// Method for adding new sms.
        /// </summary>
        /// <param name="message">Text message</param>
        /// <param name="phoneNumber">Recipient's phone number</param>
        /// <param name="sendAt">Date when sms should be send.</param>
        /// <returns></returns>
        Task AddNewAsync(string message, string phoneNumber, DateTime sendAt);

        /// <summary>
        /// Method for getting one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns>One object of SMSDto</returns>
        Task<SMSDto> GetAsync(Guid id);

        /// <summary>
        /// Method for getting all sms'.
        /// </summary>
        /// <returns>List of SMSDto</returns>
        Task<IEnumerable<SMSDto>> GetAllReadyToSent();

        /// <summary>
        /// Method for removing one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns></returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Method for mapping SMS object to SMSDto object.
        /// </summary>
        /// <param name="sms">object for mapping</param>
        /// <returns></returns>
        SMSDto MapSMS(SMS sms);
    }
}
