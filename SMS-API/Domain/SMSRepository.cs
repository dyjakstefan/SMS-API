using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Api.Domain
{
    public class SMSRepository : ISMSRepository, IMongoRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public SMSRepository()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("SMS");
        }

        public async Task AddAsync(SMS sms)
            => await SMSs.InsertOneAsync(sms);

        public async Task<IEnumerable<SMS>> GetAllAsync()
            => await SMSs.AsQueryable().ToListAsync();


        public async Task<SMS> GetAsync(Guid id)
            => await SMSs.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(Guid id)
            => await SMSs.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateAsync(SMS sms)
            => await SMSs.ReplaceOneAsync(x => x.Id == sms.Id, sms);

        private IMongoCollection<SMS> SMSs => _database.GetCollection<SMS>("SMSs");
    }
}
