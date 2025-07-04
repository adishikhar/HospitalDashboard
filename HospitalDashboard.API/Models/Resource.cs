using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HospitalDashboard.API.Models
{
    public class Resource
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
