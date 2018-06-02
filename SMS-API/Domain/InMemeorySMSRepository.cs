using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class InMemeorySMSRepository : ISMSRepository
    {
        private static ISet<SMS> _sms = new HashSet<SMS>()
        {
            new SMS(Guid.NewGuid(), "Pierwsza wiadomosc", "12345678", new DateTime(1990,10,10)),
            new SMS(Guid.NewGuid(), "Druga wiadomosc", "12345678", new DateTime(1990,10,10)),
        };

        public async Task AddAsync(SMS sms)
        {
            _sms.Add(sms);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<SMS>> GetAllAsync()
            => await Task.FromResult(_sms);

        public async Task<SMS> GetAsync(Guid id)
            => await Task.FromResult(_sms.SingleOrDefault(x => x.Id == id));

        public async Task RemoveAsync(Guid id)
        {
            var sms = await GetAsync(id);
            _sms.Remove(sms);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(SMS sms)
        {
            var oldSMS = await GetAsync(sms.Id);
            _sms.Remove(oldSMS);
            _sms.Add(sms);
            await Task.CompletedTask;
        }
    }
}
