using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    /// <summary>
    /// Interface for SMS repository.
    /// </summary>
    public interface ISMSRepository : IRepository
    {
        /// <summary>
        /// Method for getting one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns>SMS Model</returns>
        Task<SMS> GetAsync(Guid id);

        /// <summary>
        /// Method for getting all sms's from set.
        /// </summary>
        /// <returns>Collection of sms's</returns>
        Task<IEnumerable<SMS>> GetAllAsync();

        /// <summary>
        /// Method for adding new sms into set.
        /// </summary>
        /// <param name="sms">New sms.</param>
        /// <returns></returns>
        Task AddAsync(SMS sms);

        /// <summary>
        /// Delete one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns></returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Update sms.
        /// </summary>
        /// <param name="sms">Updated sms</param>
        /// <returns></returns>
        Task UpdateAsync(SMS sms);
    }
}
