using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class SMSService : ISMSService
    {
        private readonly ISMSRepository _smsRepository;
        
        public SMSService(ISMSRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        public async Task AddNewAsync(string message, string phoneNumber, DateTime sendAt)
        {
            var sms = new SMS(Guid.NewGuid(), message, phoneNumber, sendAt);
            await _smsRepository.AddAsync(sms);
        }

        public async Task<SMSDto> GetAsync(Guid id)
        {
            var sms = await _smsRepository.GetAsync(id);

            return MapSMS(sms);
        }

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

        public async Task RemoveAsync(Guid id)
        {
            await _smsRepository.RemoveAsync(id);
        }

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
