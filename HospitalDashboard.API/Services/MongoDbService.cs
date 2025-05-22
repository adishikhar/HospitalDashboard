using HospitalDashboard.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HospitalDashboard.API.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Resource> _resources;

        public MongoDbService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:Database"]);
            _resources = database.GetCollection<Resource>("Resources");
        }

        public async Task<List<Resource>> GetAll() =>
            await _resources.Find(_ => true).ToListAsync();

        public async Task<Resource> GetById(string id) =>
            await _resources.Find(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<Resource> Create(Resource resource)
        {
            await _resources.InsertOneAsync(resource);
            return resource;
        }

        public async Task Update(string id, Resource updated) =>
            await _resources.ReplaceOneAsync(r => r.Id == id, updated);

        public async Task Delete(string id) =>
            await _resources.DeleteOneAsync(r => r.Id == id);
    }
}
