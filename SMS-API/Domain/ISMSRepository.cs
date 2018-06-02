using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public interface ISMSRepository : IRepository
    {
        Task<SMS> GetAsync(Guid id);
        Task<IEnumerable<SMS>> GetAllAsync();
        Task AddAsync(SMS sms);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(SMS sms);
    }
}
