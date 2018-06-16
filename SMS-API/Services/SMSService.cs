using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class SMSService : ISMSService
    {
        /// <summary>
        /// Private member of sms repository.
        /// </summary>
        private readonly ISMSRepository _smsRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smsRepository">Sms' repository</param>
        public SMSService(ISMSRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        /// <summary>
        /// Method for adding new sms.
        /// </summary>
        /// <param name="message">Text message</param>
        /// <param name="phoneNumber">Recipient's phone number</param>
        /// <param name="sendAt">Date when sms should be send.</param>
        /// <returns></returns>
        public async Task AddNewAsync(string message, string phoneNumber, DateTime sendAt)
        {
            var sms = new SMS(Guid.NewGuid(), message, phoneNumber, sendAt);
            await _smsRepository.AddAsync(sms);
        }

        /// <summary>
        /// Method for getting one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns>One object of SMSDto</returns>
        public async Task<SMSDto> GetAsync(Guid id)
        {
            var sms = await _smsRepository.GetAsync(id);

            return MapSMS(sms);
        }

        /// <summary>
        /// Method for getting all sms'.
        /// </summary>
        /// <returns>List of SMSDto</returns>
        public async Task<IEnumerable<SMSDto>> GetAllReadyToSent()
        {
            DateTime now = DateTime.UtcNow;
            var smsList = await _smsRepository.GetAllAsync();
            var newList = new List<SMSDto>();
            foreach(var s in smsList)
            {
                if(s.SendAt.CompareTo(now) <= 0)
                {
                    newList.Add(MapSMS(s));
                }
            }
            return newList;
        }

        /// <summary>
        /// Method for removing one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid id)
        {
            await _smsRepository.RemoveAsync(id);
        }

        /// <summary>
        /// Method for mapping SMS object to SMSDto object.
        /// </summary>
        /// <param name="sms">object for mapping</param>
        /// <returns></returns>
        public SMSDto MapSMS(SMS sms)
        {
            var smsDto = new SMSDto
            {
                Id = sms.Id,
                Message = sms.Message,
                PhoneNumber = sms.PhoneNumber
            };

            return smsDto;
        }
    }
}
