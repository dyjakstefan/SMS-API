using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    /// <summary>
    /// Class for repository that holds data in memory.
    /// </summary>
    public class InMemeorySMSRepository : ISMSRepository
    {
        /// <summary>
        /// Set of default sms's
        /// </summary>
        private static ISet<SMS> _sms = new HashSet<SMS>()
        {
            new SMS(Guid.NewGuid(), "Pierwsza wiadomosc", "12345678", new DateTime(1990,10,10)),
            new SMS(Guid.NewGuid(), "Druga wiadomosc", "12345678", new DateTime(1990,10,10)),
        };

        /// <summary>
        /// Method for adding new sms into set.
        /// </summary>
        /// <param name="sms">New sms.</param>
        /// <returns></returns>
        public async Task AddAsync(SMS sms)
        {
            _sms.Add(sms);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Method for getting all sms's from set.
        /// </summary>
        /// <returns>Collection of sms's</returns>
        public async Task<IEnumerable<SMS>> GetAllAsync()
            => await Task.FromResult(_sms);

        /// <summary>
        /// Method for getting one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns>SMS Model</returns>
        public async Task<SMS> GetAsync(Guid id)
            => await Task.FromResult(_sms.SingleOrDefault(x => x.Id == id));

        /// <summary>
        /// Delete one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid id)
        {
            var sms = await GetAsync(id);
            _sms.Remove(sms);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Update sms.
        /// </summary>
        /// <param name="sms">Updated sms</param>
        /// <returns></returns>
        public async Task UpdateAsync(SMS sms)
        {
            var oldSMS = await GetAsync(sms.Id);
            _sms.Remove(oldSMS);
            _sms.Add(sms);
            await Task.CompletedTask;
        }
    }
}
