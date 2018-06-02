using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public interface ISMSService : IService
    {
        Task AddNewAsync(string message, string phoneNumber, DateTime sendAt);
        Task<SMSDto> GetAsync(Guid id);
        Task<IEnumerable<SMSDto>> GetAllReadyToSent();
        Task RemoveAsync(Guid id);
        SMSDto MapSMS(SMS sms);
    }
}
