using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities
{
    public class ProductBrand:BaseEntity
    {
        //[BsonElement("name")] name of brandName in database
        public string Name { get; set; }
    }
}