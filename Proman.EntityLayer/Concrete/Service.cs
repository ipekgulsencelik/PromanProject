using MongoDB.Bson.Serialization.Attributes;
using Proman.EntityLayer.Abstract;

namespace Proman.EntityLayer.Concrete
{
    public class Service : IMongoBaseEntity
    {
        public string? ServiceTitle { get; set; }
        public string? ServiceDescription { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal ServicePrice { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool IsHome { get; set; }
    }
}