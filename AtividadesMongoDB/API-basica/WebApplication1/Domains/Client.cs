using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }


        [BsonElement("userId"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? UserId { get; set; }


        [BsonElement("cpf")]
        public string? Cpf { get; set;}


        [BsonElement("phone")]
        public string? Phone { get; set; }


        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string> AdditionalAttributs { get; set; }
        public Client()
        {
            AdditionalAttributs = new Dictionary<string, string>();
        }




    }
}
