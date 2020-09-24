namespace finance_app_api.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Account
    {
        [BsonId]
        public ObjectId InternalId {get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}