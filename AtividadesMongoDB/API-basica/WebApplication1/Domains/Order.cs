using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Domains
{
    public class Order
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
        public List<Product>? Products { get; set; }


        // ref ao cliente q esta fznd o pedido
        [BsonElement("client")]
        public Client? Client { get; set; }
        public string? ClientId { get; set; }

    }
}
