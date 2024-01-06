using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmailService.Models;

public abstract class ModelBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }   
}