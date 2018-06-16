using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    /// <summary>
    /// Class for repository that holds data in database.
    /// </summary>
    public class SMSRepository : ISMSRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="database">Mongo Database.</param>
        public SMSRepository(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Method for adding new sms into database.
        /// </summary>
        /// <param name="sms">New sms.</param>
        /// <returns></returns>
        public async Task AddAsync(SMS sms)
            => await SMSs.InsertOneAsync(sms);

        /// <summary>
        /// Method for getting all sms's from database.
        /// </summary>
        /// <returns>Collection of sms's</returns>
        public async Task<IEnumerable<SMS>> GetAllAsync()
            => await SMSs.AsQueryable().ToListAsync();


        /// <summary>
        /// Method for getting one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns>SMS Model</returns>
        public async Task<SMS> GetAsync(Guid id)
            => await SMSs.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        /// <summary>
        /// Delete one sms with specific id.
        /// </summary>
        /// <param name="id">Id of sms</param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid id)
            => await SMSs.DeleteOneAsync(x => x.Id == id);

        /// <summary>
        /// Update sms.
        /// </summary>
        /// <param name="sms">Updated sms</param>
        /// <returns></returns>
        public async Task UpdateAsync(SMS sms)
            => await SMSs.ReplaceOneAsync(x => x.Id == sms.Id, sms);

        /// <summary>
        /// Collection of sms's from database.
        /// </summary>
        private IMongoCollection<SMS> SMSs => _database.GetCollection<SMS>("SMSs");
    }
}
