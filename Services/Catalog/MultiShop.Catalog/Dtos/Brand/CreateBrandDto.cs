using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Dtos.Brand
{
    public class CreateBrandDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
