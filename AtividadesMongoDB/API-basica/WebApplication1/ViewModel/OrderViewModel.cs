using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using WebApplication1.Domains;

namespace WebApplication1.ViewModel
{
    public class OrderViewModel
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }


        // Lista de produtos associados ao pedido
        [BsonElement("productId")]
        
        public List<string> ProductId { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public List<Product>? Products { get; set; }


        // ref ao cliente q esta fznd o pedido
        [BsonIgnore]
        [JsonIgnore]
        public Client? Client { get; set; }
        
        [BsonElement("client")]
        public string? ClientId { get; set; }

    }
}

