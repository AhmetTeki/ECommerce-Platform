using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class SpecialDiscount
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string SpecialDiscountId { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string ImageUrl { get; set; }
}