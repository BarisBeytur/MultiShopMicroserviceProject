using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public interface IEntity
    {
        public string Id { get; set; }
    }
}
