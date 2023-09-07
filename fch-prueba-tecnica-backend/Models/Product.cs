using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fch_prueba_tecnica_backend.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string prodCode { get; set; }

        public string prodName { get; set; }

        public string prodManofacturer { get; set; }

        public string prodModel { get; set; }

        public decimal price { get; set; }

        public int stock { get; set; }
    }
}
